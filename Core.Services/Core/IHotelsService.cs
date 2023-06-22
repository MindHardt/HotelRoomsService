using Core.Entities;

namespace Core.Services.Core;

public interface IHotelsService
{
    public Task<IReadOnlyCollection<HotelData>> GetAllHotelsAsync();
    public Task<HotelData?> GetByCoordinates(float latitude, float longitude);

}