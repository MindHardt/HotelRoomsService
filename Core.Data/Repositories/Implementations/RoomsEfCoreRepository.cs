using AutoMapper;
using Bogus;
using Core.Data.Repositories.Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
            .Where(r => r.Hotel.Latitude == lat && r.Hotel.Longitude == lon)
            .ToArrayAsync();
    }

    public async Task<Room?> GetRoom(float lat, float lon, int number)
    {
        return await Set
            .Where(r => r.Hotel.Latitude == lat && r.Hotel.Longitude == lon)
            .FirstOrDefaultAsync(r => r.Number == number);
    }

    public async Task<Room?> UpdateRoom(Room room)
    {
        // Репозиторий не содержит логики, только обновляет данные которые к нему пришли
        var entry = Set.Update(room);
        await CommitAsync();

        return entry.Entity;
    }
}
