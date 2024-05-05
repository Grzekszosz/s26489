using Microsoft.AspNetCore.Mvc;
using WebApplication2.Model;
using WebApplication2.Services;

namespace WebApplication2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WareHouseController2 : ControllerBase
{
    private IWareHouseService2 _wareHouseService2;

    public WareHouseController2(IWareHouseService2 wareHouseService)
    {
        _wareHouseService2 = wareHouseService;
    }

    [HttpPut]
    public async Task<IActionResult> AddProductProcedureAsync(Product product)
    {
        try
        {
            var a = await _wareHouseService2.AddProductProcedureAsync(product);
            return StatusCode(StatusCodes.Status201Created, new {IdProductWarehouse = a} );    
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}