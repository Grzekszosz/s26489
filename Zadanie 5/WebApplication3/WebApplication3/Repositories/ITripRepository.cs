using System.Collections;
using WebApplication3.Context;
using WebApplication3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace WebApplication3.Repositories;

public interface ITripRepository
{
     Task<IEnumerable<TripDto>> GetTripsAsync();
     Task<bool> ClientConnections(int id);
     Task<bool> DeleteClient(int id);
     Task<Client> GetClientByPesel(object pesel);
     Task<bool> ClientTripExists(int clientIdClient, int idTrip);
     Task AddClient(Client client);
     Task<bool> AddClientToTrip(ClientTrip clientTrip);
     Task<bool> TripExists(int idTrip);
}