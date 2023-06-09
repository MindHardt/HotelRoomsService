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

    public async Task<Hotel?> GetByIdAsync(long id)
    {
        return await _hotelsRepository.GetHotel(id);
    }

    public async Task<Hotel?> GetByAddressAsync(string address)
    {
        return await _hotelsRepository.GetHotel(address);
    }
}