using System.Net.NetworkInformation;
using WebApplication2.Model;
using WebApplication2.Repositories;

namespace WebApplication2.Services;

public class WareHouseService2 : IWareHouseService2
{
    private readonly IWareHouseRepository2 _wareHouseRepository2;

    public WareHouseService2(IWareHouseRepository2 wareHouseService)
    {
        _wareHouseRepository2 = wareHouseService;
    }

    public async Task<int> AddProductProcedureAsync(Product product)
    {
        return await _wareHouseRepository2.AddProductProcedureAsync(product);
    }
}   