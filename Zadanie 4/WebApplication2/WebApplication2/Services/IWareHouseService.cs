using WebApplication2.Model;

namespace WebApplication2.Services;

public interface IWareHouseService
{
    Task<int> AddProductAsync(Product product);
    Task<bool> AvaliableProductAsync(Product product);
    Task<bool> AvaliableOrderAsync(Product product);
}