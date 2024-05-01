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

    public async Task<bool> AvaliableProductAsync(int IDProduct)
    {
        var connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        using var con = new SqlConnection(connectionString);
        using var cmd = new SqlCommand();
        cmd.CommandText = "SELECT COUNT(1) FROM s26489.dbo.Product WHERE IdProduct = @IDProduct";
        cmd.Parameters.AddWithValue("@IDProduct" , IDProduct);
        await con.OpenAsync();
        if (await cmd.ExecuteScalarAsync() is not null)
        {
            return true;
        }
        return false;
    }
}