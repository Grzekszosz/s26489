using System.Collections;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Services;

public class TripService : ITripService
{
    private readonly ITripRepository _tripRepository;

    public TripService(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }

    public async Task<IEnumerable<TripDto>> GetTripsAsync()
    {
        return await _tripRepository.GetTripsAsync();
    }

    public async Task<bool> DeleteClient(int id)
    {
        if (!await _tripRepository.ClientConnections(id))
        {
            throw new Exception("Wybrany klient ma połączenia do wycieczek");
        }

        if (!await _tripRepository.DeleteClient(id))
        {
            throw new Exception("Nie znaleziono klienta o takim id");
        }

        return await _tripRepository.DeleteClient(id);
    }

    public async Task<bool> ClientConnections(int id)
    {
        return await _tripRepository.ClientConnections(id);
    }

    public async Task<bool> AddClientToTrip(int idTrip, ClientTripDTO clientTripDto)
    {
        if (!await _tripRepository.TripExists(idTrip))
        {
            throw new Exception("Nie znaleziono wycieczki.");
        }
        
        var client = await _tripRepository.GetClientByPesel(clientTripDto.Client.Pesel);
        if (client == null)
        {
            client = new Client
            {
                            FirstName = clientTripDto.Client.FirstName,
                            LastName = clientTripDto.Client.LastName,
                            Email = clientTripDto.Client.Email,
                            Telephone = clientTripDto.Client.Telephone,
                            Pesel = clientTripDto.Client.Pesel
            };
            await _tripRepository.AddClient(client);
        }
        
        if (await _tripRepository.ClientTripExists(client.IdClient, idTrip))
        {
            throw new Exception("Klient jest już zapisany na tą wycieczkę");
        }
        
        var clientTrip = new ClientTrip
        {
                        IdClient = client.IdClient,
                        IdTrip = idTrip,
                        PaymentDate = clientTripDto.PaymentDate,
                        RegisteredAt = DateTime.Now
        };
        return await _tripRepository.AddClientToTrip(clientTrip);
    }

    public Task<Client> GetClientByPesel(string pesel)
    {
        throw new NotImplementedException();
    }
}

