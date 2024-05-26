using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Services;

public interface ITripService
{
    Task<IEnumerable<TripDto>> GetTripsAsync();
}