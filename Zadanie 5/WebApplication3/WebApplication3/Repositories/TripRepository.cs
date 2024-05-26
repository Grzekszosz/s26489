using System.Collections;
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
                                        DateFrom = t.DateFrom.ToString("yyyy-MM-dd"), 
                                        DateTo = t.DateTo.ToString("yyyy-MM-dd"),     
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

    public async Task<bool> ClientConnections(int id)
    {
        var dbContext = new S26489Context();
        return await dbContext.ClientTrips.AnyAsync(ct => ct.IdClient == id);
    }

    public async Task<bool> DeleteClient(int id)
    {
        var dbContext = new S26489Context();
        var client = await dbContext.Clients.FindAsync(id);
        if (client == null)
        {
            return false;
        }
        dbContext.Clients.Remove(client);
        await dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<Client> GetClientByPesel(string pesel)
    {
        var dbContext = new S26489Context();
        return await dbContext.Clients.FirstOrDefaultAsync(c => c.Pesel == pesel);
    }

    public async Task<bool> AddClient(Client client)
    {
        var dbContext = new S26489Context();
        dbContext.Clients.Add(client);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> TripExists(int idTrip)
    {
        var dbContext = new S26489Context();
        return await dbContext.Trips.AnyAsync(t => t.IdTrip == idTrip);
    }

    public async Task<bool> ClientTripExists(int clientId, int tripId)
    {
        var dbContext = new S26489Context();
        return await dbContext.ClientTrips.AnyAsync(ct => ct.IdClient == clientId && ct.IdTrip == tripId);
    }



    public async Task<bool> AddClientToTrip(ClientTrip clientTrip)
    {
        var dbContext = new S26489Context();
        dbContext.ClientTrips.Add(clientTrip);
        await dbContext.SaveChangesAsync();
        return true;
    }
    Task ITripRepository.AddClient(Client client)
    {
        return AddClient(client);
    }
    public Task<Client> GetClientByPesel(object pesel)
    {
        throw new NotImplementedException();
    }
}