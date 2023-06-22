using Core.Data.Repositories.Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repositories.Implementations;

public class HotelsEfCoreRepository:
    EfCoreRepositoryBase<Hotel>,
    IHotelsRepository
{
    public HotelsEfCoreRepository(DbContext ctx) : base(ctx)
    { }

    public async Task<IReadOnlyCollection<HotelData>> GetAllHotels()
    {
        return await Set
            .OrderBy(h => h.Id)
            .Select(h => new HotelData
            {
                Longitude = h.Longitude,
                Latitude = h.Latitude,
                MaxPrice = h.Rooms.Max(r => r.Price),
                MinPrice = h.Rooms.Min(r => r.Price),
            })
            .ToArrayAsync();
    }

    public async Task<HotelData?> GetHotel(float lat, float lon)
    {
        return await Set
            .Include(h => h.Rooms)
            .Where(h => h.Latitude == lat && h.Longitude == lon)
            .Select(h => new HotelData
            {
                Longitude = h.Longitude,
                Latitude = h.Latitude,
                Rooms = h.Rooms,
                MaxPrice = h.Rooms.Max(r => r.Price),
                MinPrice = h.Rooms.Min(r => r.Price),
            })
            .FirstOrDefaultAsync();
    }
}