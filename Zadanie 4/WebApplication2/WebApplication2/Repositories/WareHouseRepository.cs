using System.Data.Common;
using Microsoft.Data.SqlClient;
using WebApplication2.Model;

namespace WebApplication2.Repositories;

public class WareHouseRepository : IWareHouseRepository
{
    private IConfiguration _configuration;

    public WareHouseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<int> AddProductAsync(Product product)
    {
        var connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        var FulfilledAt = DateTime.Now;
        using var con = new SqlConnection(connectionString);
        using var cmd =
            new SqlCommand(
                "UPDATE s26489.dbo.[Order] SET FulfilledAt = @FulfilledAt WHERE IdProduct = @IDProduct and Amount = @Amount and CreatedAt < @CreatedAt",
                con);
        cmd.Parameters.AddWithValue("@IDProduct", product.IDProduct);
        cmd.Parameters.AddWithValue("@Amount", product.Amount);
        cmd.Parameters.AddWithValue("@CreatedAt", product.CreatedAt);
        cmd.Parameters.AddWithValue("@FulfilledAt", FulfilledAt);
        await con.OpenAsync();
        var affectedCount = await cmd.ExecuteNonQueryAsync();
        con.Close();
        cmd.CommandText =
            "SELECT IdOrder FROM s26489.dbo.[Order] WHERE IdProduct = @IDProduct and Amount = @Amount and CreatedAt < @CreatedAt";
        await con.OpenAsync();
        var rid = await cmd.ExecuteReaderAsync();
        var idOrder = 0;
        while (rid.Read())
        {
            idOrder = (int)rid["IdOrder"];
        }

        con.Close();
        cmd.CommandText = "SELECT Price FROM s26489.dbo.Product WHERE IdProduct = @IDProduct";
        await con.OpenAsync();
        rid = await cmd.ExecuteReaderAsync();
        double cena = 0;
        while (rid.Read())
        {
            cena = (double)(decimal)rid["Price"];
        }

        con.Close();
            //Wyciągnąć Cene z produktu oraz ID Order
        cena = cena * product.Amount;
        var cmds = new SqlCommand("INSERT INTO s26489.dbo.Product_Warehouse (IdWarehouse,IdProduct,IdOrder,Amount,Price,CreatedAt) VALUES(@IdWarehouse,@IdProduct,@IdOrder,@Amount,@Price,@FulfilledAt); SELECT SCOPE_IDENTITY()",con);
            
                cmds.Parameters.AddWithValue("@IdWarehouse", product.IDWarehouse);
                cmds.Parameters.AddWithValue("@IdProduct", product.IDProduct);
                cmds.Parameters.AddWithValue("@IdOrder", idOrder);
                cmds.Parameters.AddWithValue("@Amount", product.Amount);
                cmds.Parameters.AddWithValue("@FulfilledAt", FulfilledAt);
                cmds.Parameters.AddWithValue("@Price", cena);
                await con.OpenAsync();
                int insertedId = (int)(decimal)await cmds.ExecuteScalarAsync();
                System.Console.WriteLine(insertedId);
                con.Close();
                return insertedId;
        
    }

    public async Task<bool> AvaliableProductAsync(Product product)
    {
        var connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        using var con = new SqlConnection(connectionString);
        using var cmd = new SqlCommand("SELECT COUNT(1) FROM s26489.dbo.[Product] WHERE IdProduct = @IDProduct",con);
        cmd.Parameters.AddWithValue("@IDProduct" , product.IDProduct);
        await con.OpenAsync();
        var affectedCount= await cmd.ExecuteScalarAsync();
        con.Close();
        if ((int)affectedCount ==1 && product.Amount > 0)
        {
            using var cmds = new SqlCommand("SELECT COUNT (1) FROM s26489.dbo.Warehouse WHERE IdWarehouse = @IdWarehouse", con);
            cmds.Parameters.AddWithValue("@IdWarehouse", product.IDWarehouse);
            await con.OpenAsync();
            var affectedWarehouse= await cmds.ExecuteScalarAsync();
            con.Close();
            if ((int)affectedWarehouse == 1)
            {
                return true;    
            }
        }
        return false;
    }

    public async Task<bool> AvaliableOrderAsync(Product product)
    {
        var connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        using var con = new SqlConnection(connectionString);
        using var cmd = new SqlCommand("SELECT COUNT(1) FROM s26489.dbo.[Order] WHERE IdProduct = @IDProduct and Amount = @Amount and CreatedAt < @CreatedAt",con);
        cmd.Parameters.AddWithValue("@IDProduct", product.IDProduct);
        cmd.Parameters.AddWithValue("@Amount", product.Amount);
        cmd.Parameters.AddWithValue("@CreatedAt", product.CreatedAt);
        await con.OpenAsync();
        var affectedCount = await cmd.ExecuteScalarAsync();
        if((int)affectedCount == 1 )
        {
            return true;
        }

        return false;
    }

    public async Task<bool> AlredyOrderedAsync(Product product)
    {
        var connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        using var con = new SqlConnection(connectionString);
        using var cmd = new SqlCommand("SELECT IdOrder FROM s26489.dbo.[Order] WHERE IdProduct = @IDProduct and Amount = @Amount and CreatedAt < @CreatedAt", con);
        cmd.Parameters.AddWithValue("@IDProduct", product.IDProduct);
        cmd.Parameters.AddWithValue("@Amount", product.Amount);
        cmd.Parameters.AddWithValue("@CreatedAt", product.CreatedAt);
        await con.OpenAsync();
        var rid = cmd.ExecuteReader();
        var idOrder = 0; 
        while (rid.Read())
        {
            idOrder = (int)rid["IdOrder"];
        }

        if (idOrder == 0)
        {
            return false;
        }
        con.Close();
        using var cmds = new SqlCommand("SELECT (1) FROM s26489.dbo.Product_Warehouse WHERE IdOrder = @IdOrder",con);
        cmds.Parameters.AddWithValue("@IdOrder", idOrder);
        await con.OpenAsync();
        var affectedCount = await cmds.ExecuteScalarAsync();
        if(affectedCount == null )
        {
            return true;
        }
        return false;
    }  
}
