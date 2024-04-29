using Microsoft.AspNetCore.Mvc;
using WebApplication2.Model;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class WareHouseController : ControllerBase
{
    private IWareHouseService _wareHouseService;

    public WareHouseController(IWareHouseService wareHouseService)
    {
        _wareHouseService = wareHouseService;
    }

    [HttpPut]
    public IActionResult AddProduct(Product product)
    {
        
        return product;
    }
}

