using Microsoft.AspNetCore.Mvc;
using WebApplication4.Context;
using WebApplication4.Models;
using WebApplication4.Models.DTO;

namespace WebApplication4.Controllers;
[Route("api/prescription")]
[ApiController]
public class PrescriptionController:ControllerBase
{
    private readonly APBDContext dbContext;

    public PrescriptionController(APBDContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpPost("addPrescritpion")]
    public async Task<ActionResult> AddPrescription(NewRecipe dto)
    {
        
        return Ok();
    }
}