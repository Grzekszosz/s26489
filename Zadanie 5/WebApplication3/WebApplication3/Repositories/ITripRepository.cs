using WebApplication3.Context;
using WebApplication3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace WebApplication3.Repositories;

public interface ITripRepository
{
     Task<IEnumerable<TripDto>> GetTripsAsync();
}