using WebApplication2.Model;

namespace WebApplication2.Repositories;

public interface IWareHouseRepository
{
    Task<int> AddProductAsync(Product product);
    Task<bool> AvaliableProductAsync(Product product);
    Task<bool> AvaliableOrderAsync(Product product);
    Task<bool> AlredyOrderedAsync(Product product);
}