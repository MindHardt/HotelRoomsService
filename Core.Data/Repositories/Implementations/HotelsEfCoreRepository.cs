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

    public async Task<IReadOnlyCollection<Hotel>> GetAllHotels()
    {
        return await Set
            .OrderBy(h => h.Id)
            .ToArrayAsync();
    }

    public async Task<Hotel?> GetHotel(float lat, float lon)
    {
        return await Set
            .Include(h => h.Rooms)
            .FirstOrDefaultAsync(h => h.Latitude == lat && h.Longitude == lon);
    }

    public async Task<decimal?> GetMinRoomPrices(float lat, float lon)
    {
        return await Set.Where(h => h.Latitude == lat && h.Longitude == lon)
            .Select(h => h.Rooms.Min(r => r.Price))
            .FirstOrDefaultAsync();
    }

    public async Task<decimal?> GetMaxRoomPrices(float lat, float lon)
    {
        return await Set.Where(h => h.Latitude == lat && h.Longitude == lon)
            .Select(h => h.Rooms.Max(r => r.Price))
            .FirstOrDefaultAsync();
    }
}