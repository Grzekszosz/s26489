using WebApplication2.Model;
using WebApplication2.Repositories;

namespace WebApplication2.Services;

public class WareHouseService : IWareHouseService
{
    private readonly IWareHouseRepository _wareHouseRepository;

    public WareHouseService(IWareHouseRepository wareHouseService)
    {
        _wareHouseRepository = wareHouseService;
    }
    public async Task <int> AddProductAsync (Product product)
    {
        if (!_wareHouseRepository.AvaliableProductAsync(product.IDProduct))
        {
            throw new Exception("Nie ma produktu");
        }
        return await _wareHouseRepository.AddProductAsync(product);
    }

    public async bool AvaliableProductAsync(int IDProdukt)
    {
        throw new NotImplementedException();
    }
}   