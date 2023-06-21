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
    private readonly DbContext _ctx;

    public RoomsEfCoreRepository(DbContext ctx) : base(ctx)
    {
        _ctx = ctx;
    }

    public async Task<IReadOnlyCollection<Room>> GetAllRooms(float lat, float lon)
    {
        return await Set
            .Include(r => r.Hotel)
            .Where(r => r.Hotel.Latitude == lat && r.Hotel.Longitude == lon)
            .ToArrayAsync();
    }

    public async Task<Room?> GetRoom(float lat, float lon, int number)
    {
        return await Set
            .Include(r => r.Hotel)
            .Where(r => r.Hotel.Latitude == lat && r.Hotel.Longitude == lon)
            .FirstOrDefaultAsync(r => r.Number == number);
    }

    public async Task<Room?> UpdateRoom(Room room)
    {
        return await Task.Run(() => {
            var dbRoom = Set.Find(room.Number);

            if (dbRoom is null)
                return null;

            dbRoom.State = room.State;
            dbRoom.Price = room.Price;
            dbRoom.Class = room.Class;
            dbRoom.Floor = room.Floor;
            dbRoom.ImageUrl = room.ImageUrl;

            _ctx.SaveChanges();

            return dbRoom;
        });
    }
}
