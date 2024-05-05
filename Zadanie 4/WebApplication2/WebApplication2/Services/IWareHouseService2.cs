using WebApplication2.Model;

namespace WebApplication2.Services;

public interface IWareHouseService2
{
    Task<int> AddProductProcedureAsync(Product product);
}