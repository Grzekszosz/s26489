using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TripController : ControllerBase
{
    private ITripService _tripService;

    public TripController(ITripService tripService)
    {
        _tripService = tripService;
    }
    [HttpGet]
    public async Task<IActionResult> GetTripsAsync()
    {
        try
        {
            var trips = await _tripService.GetTripsAsync();
            return Ok(trips);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        try
        {
            if (await _tripService.ClientConnections(id))
            {
                return BadRequest("Klient ma powiązania do wycieczek");
            }
            var affectedCount = await _tripService.DeleteClient(id);
            if (!affectedCount)
            {
                return NotFound("Nie znaleziono klienta");
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpPost("{idTrip}/clients")]
    public async Task<IActionResult> AddClientToTrip(int idTrip, [FromBody] ClientTripDTO clientTripDto)
    {
        try
        {
            var result = await _tripService.AddClientToTrip(idTrip, clientTripDto);
            if (!result)
            {
                return BadRequest("Nie udało się dodać klienta");
            }
            return Ok("Dodano Klienta.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}