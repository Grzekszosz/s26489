using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Context;
using WebApplication3.Models;

namespace WebApplication3.Repositories;

public class TripRepository : ITripRepository
{
    public async Task<IEnumerable<TripDto>> GetTripsAsync()
    {
        var dbContext = new S26489Context();

        return await dbContext.Trips
                        .Include(t => t.IdCountries)
                        .Include(t => t.ClientTrips)
                        .ThenInclude(ct => ct.IdClientNavigation)
                        .Select(t => new TripDto
                        {
                                        Name = t.Name,
                                        Description = t.Description,
                                        DateFrom = t.DateFrom.ToString("yyyy-MM-dd"), // Formatowanie daty
                                        DateTo = t.DateTo.ToString("yyyy-MM-dd"),     // Formatowanie daty
                                        MaxPeople = t.MaxPeople,
                                        Countries = t.IdCountries.Select(c => new CountryDto
                                        {
                                                        Name = c.Name
                                        }).ToList(),
                                        Clients = t.ClientTrips.Select(ct => new ClientDto
                                        {
                                                        FirstName = ct.IdClientNavigation.FirstName,
                                                        LastName = ct.IdClientNavigation.LastName
                                        }).ToList()
                        })
                        .ToListAsync();
    }
}