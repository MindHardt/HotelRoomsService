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
        var entry = Set.Update(room);
        await CommitAsync();
        return entry.Entity;
    }

    public async Task AddRoomModifiers()
    {
        var modifiers = new[]
        {
            new[]
            {
                new RoomModifier() { Id = 1, Name = "Двуспальная кровать" },
                new RoomModifier() { Id = 2, Name = "Односпальная кровать" },
            },
            new[]
            {
                new RoomModifier() { Id = 3, Name = "Питание включено" },
                new RoomModifier() { Id = 4, Name = "Питание не включено" },
            },
            new[]
            {
                new RoomModifier() { Id = 5, Name = "Сейф есть" },
                new RoomModifier() { Id = 6, Name = "Сейфа нет" },
            }
        };
        
        var rooms = await Set.ToArrayAsync();
        foreach (var room in rooms)
        {
            room.RoomModifiers.Add(modifiers[0][Random.Shared.Next(2)]);
            room.RoomModifiers.Add(modifiers[1][Random.Shared.Next(2)]);
            room.RoomModifiers.Add(modifiers[2][Random.Shared.Next(2)]);
        }

        await CommitAsync();
    }
}
