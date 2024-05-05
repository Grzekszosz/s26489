using System.Net.NetworkInformation;
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

    public async Task<int> AddProductAsync(Product product)
    {
        if (!await _wareHouseRepository.AvaliableProductAsync(product))
        {
            throw new Exception("Nie ma produktu lub magazynu");
        }

        if (!await _wareHouseRepository.AvaliableOrderAsync(product))
        {
            throw new Exception("Brak dopasowanego zamówienia");
        }

        if (!await _wareHouseRepository.AlredyOrderedAsync(product))
        {
            throw new Exception("Zamówienie zostało już zrealizowane");
        }
        return await _wareHouseRepository.AddProductAsync(product);
    }

    public async Task<bool> AvaliableProductAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AvaliableOrderAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AlredyOrderedAsync(Product product)
    {
        throw new NotImplementedException();
    }
}   