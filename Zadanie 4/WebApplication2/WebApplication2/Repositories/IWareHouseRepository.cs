using WebApplication2.Model;

namespace WebApplication2.Repositories;

public interface IWareHouseRepository
{
    Task<int> AddProductAsync(Product product);
    Task<bool> AvaliableProductAsync(int IDProduct);
}