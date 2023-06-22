using AutoMapper;
using Bogus;
using Core.Data.Repositories.Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Core.Data.Repositories.Implementations;

public class RoomsEfCoreRepository :
    EfCoreRepositoryBase<Room>,
    IRoomsRepository
{
    public RoomsEfCoreRepository(DbContext ctx) : base(ctx)
    {
    }

    public async Task<IReadOnlyCollection<Room>> GetAllRooms(float lat, float lon)
    {
        return await Set
            .AsNoTracking()
            .Where(r => r.Hotel.Latitude == lat && r.Hotel.Longitude == lon)
            .ToArrayAsync();
    }

    public async Task<Room?> GetRoom(float lat, float lon, int number)
    {
        return await Set
            .AsNoTracking()
            .Where(r => r.Hotel.Latitude == lat && r.Hotel.Longitude == lon)
            .FirstOrDefaultAsync(r => r.Number == number);
    }

    public async Task<Room?> UpdateRoom(Room room)
    {
        // Репозиторий не содержит логики, только обновляет данные которые к нему пришли
        EntityEntry<Room>? entry;
        try
        {
            entry = Set.Update(room);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        await CommitAsync();
        return entry.Entity;
    }
}
