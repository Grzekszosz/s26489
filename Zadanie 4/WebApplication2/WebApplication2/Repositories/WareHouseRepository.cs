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
        using var con = new SqlConnection(connectionString);
        
        return 3;
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
            return true;
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
}
/*
2. Możemy dodać produkt do magazynu tylko wtedy, gdy istnieje
zamówienie zakupu produktu w tabeli Order. Dlatego sprawdzamy, czy w
tabeli Order istnieje rekord z IdProduktu i Ilością (Amount), które
odpowiadają naszemu żądaniu. Data utworzenia zamówienia powinna
być wcześniejsza niż data utworzenia w żądaniu.
*/