using Core.Data.Repositories.Core;
using Core.Entities;
using Core.Services.Core;
using Core.Services.DI;

namespace Core.Services.Implementations;

[DefaultService]
public class DefaultHotelsService : IHotelsService
{
    private readonly IHotelsRepository _hotelsRepository;

    public DefaultHotelsService(IHotelsRepository hotelsRepository)
    {
        _hotelsRepository = hotelsRepository;
    }

    public Task<IReadOnlyCollection<Hotel>> GetAllHotelsAsync()
    {
        return _hotelsRepository.GetAllHotels();
    }

    public async Task<Hotel?> GetByCoordinates(float latitude, float longitude)
    {
        return await _hotelsRepository.GetHotel(latitude, longitude);
    }
    
    public Task<decimal?> GetMinRoomPriceAsync(float latitude, float longitude)
    {
        return _hotelsRepository.GetMinRoomPrices(latitude, longitude);
    }
    
    public Task<decimal?> GetMaxRoomPriceAsync(float latitude, float longitude)
    {
        return _hotelsRepository.GetMaxRoomPrices(latitude, longitude);
    }
    
}