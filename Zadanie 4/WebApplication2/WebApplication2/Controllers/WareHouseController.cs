﻿using Microsoft.AspNetCore.Mvc;
using WebApplication2.Model;
using WebApplication2.Services;

namespace WebApplication2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WareHouseController : ControllerBase
{
    private IWareHouseService _wareHouseService;

    public WareHouseController(IWareHouseService wareHouseService)
    {
        _wareHouseService = wareHouseService;
    }

    [HttpPut]
    public async Task<IActionResult> AddProductAsync(Product product)
    {
        try
        {
            var a = await _wareHouseService.AddProductAsync(product);
            return StatusCode(StatusCodes.Status201Created, new {IdProductWarehouse = a} );    
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}

