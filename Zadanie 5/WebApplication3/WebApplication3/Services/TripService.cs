using WebApplication3.Models;

namespace WebApplication3.Services;

public class TripService:ITripService
{
    private readonly ITripService _tripService;

    public TripService(ITripService tripService)
    {
        _tripService = tripService;
    }

    public async Task<Trip> GetTripsAsync()
    {
        return await _tripService.GetTripsAsync();
    }
}