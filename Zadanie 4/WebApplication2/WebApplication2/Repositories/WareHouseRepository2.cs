using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using WebApplication2.Model;

namespace WebApplication2.Repositories;

public class WareHouseRepository2 : IWareHouseRepository2
{
    private IConfiguration _configuration2;

    public WareHouseRepository2(IConfiguration configuration)
    {
        _configuration2 = configuration;
    }

    public async Task<int> AddProductProcedureAsync(Product product)
    {
        var connectionString = _configuration2["ConnectionStrings:DefaultConnection"];
        using (var connection = new SqlConnection(connectionString))
        {
            using (var command = new SqlCommand("AddProductToWarehouse", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdProduct", product.IDProduct);
                command.Parameters.AddWithValue("@IdWarehouse", product.IDWarehouse);
                command.Parameters.AddWithValue("@Amount",product.Amount);
                command.Parameters.AddWithValue("@CreatedAt", product.Amount);
                connection.Open();
                int result =  (int)(decimal)await command.ExecuteScalarAsync();
                connection.Close();
                return result;
            }
        }
    }
}
