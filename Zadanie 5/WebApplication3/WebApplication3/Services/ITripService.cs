using System.Collections;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Services;

public interface ITripService
{
    Task<IEnumerable<TripDto>> GetTripsAsync();
    Task<bool> DeleteClient(int id);
    Task<bool> ClientConnections(int id);
    Task<bool> AddClientToTrip(int idTrip, ClientTripDTO clientTripDto);
    Task<Client> GetClientByPesel(string pesel);
}