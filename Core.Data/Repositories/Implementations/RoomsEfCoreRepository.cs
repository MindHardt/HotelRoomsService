using AutoMapper;
using Bogus;
using Core.Data.Repositories.Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Core.Data.Repositories.Implementations;

public class RoomsEfCoreRepository :
    EfCoreRepositoryBase<Hotel>,
    IRoomsRepository
{
    private readonly IMapper _mapper;
    private readonly DbContext _ctx;

    public RoomsEfCoreRepository(DbContext ctx, IMapper mapper) : base(ctx)
    {
        _mapper = mapper;
        _ctx = ctx;
    }

    public async Task<IReadOnlyCollection<Room>> GetAllRooms(float lat, float lon)
    {
        return await Task.Run(() => Set
            .Include(h => h.Rooms)
            .First(h => h.Latitude == lat && h.Longitude == lon)
            .Rooms
            .OrderBy(r => r.Number)
            .ToArray());
    }

    public async Task<Room?> GetRoom(float lat, float lon, int number)
    {
        return await Task.Run(() => Set
            .Include(h => h.Rooms)
            .FirstOrDefault(h => h.Latitude == lat && h.Longitude == lon)
            ?.Rooms
            .FirstOrDefault(r => r.Number == number));
    }

    public async Task<Room?> UpdateRoom(Room room)
    {
        return await Task.Run(() => {
            var dbHotel = Set
            .Include(h => h.Rooms)
            .FirstOrDefault(h => h.Rooms.Any(r => r.Number == room.Number));

            if (dbHotel is null)
                return null;

            var dbRoom = dbHotel.Rooms.FirstOrDefault(r => r.Number == room.Number);

            if (dbRoom is null)
                return null;

            var mappedRoom = _mapper.Map(room, dbRoom);

            _ctx.SaveChanges();

            return mappedRoom;
        });
    }
}
