using WebApplication2.Model;

namespace WebApplication2.Repositories;

public interface IWareHouseRepository2
{
    Task<int> AddProductProcedureAsync(Product product);
}