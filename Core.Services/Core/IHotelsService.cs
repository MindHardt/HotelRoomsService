using Core.Entities;

namespace Core.Services.Core;

public interface IHotelsService
{
    public Task<IReadOnlyCollection<Hotel>> GetAllHotelsAsync();
    public Task<Hotel?> GetByCoordinates(float latitude, float longitude);
    public Task<decimal?> GetMinRoomPriceAsync(float latitude, float longitude);
    public Task<decimal?> GetMaxRoomPriceAsync(float latitude, float longitude);
}
