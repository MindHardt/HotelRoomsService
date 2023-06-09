using Core.Entities;

namespace Core.Services.Core;

public interface IHotelsService
{
    public Task<IReadOnlyCollection<Hotel>> GetAllHotelsAsync();
    public Task<Hotel?> GetByIdAsync(long id);
    public Task<Hotel?> GetByAddressAsync(string address);
}