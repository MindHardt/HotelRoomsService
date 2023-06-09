using Core.Entities;

namespace Core.Data.Repositories.Core;

public interface IHotelsRepository
{
    /// <summary>
    /// Gets all the hotels without their rooms for overview.
    /// </summary>
    /// <returns></returns>
    public Task<IReadOnlyCollection<Hotel>> GetAllHotels();

    /// <summary>
    /// Searches for hotel with specified parameters.
    /// </summary>
    /// <param name="id">The id of the hotel.</param>
    /// <returns>The found <see cref="Hotel"/> or <see langword="null"/> if none is found.</returns>
    public Task<Hotel?> GetHotel(long id);
    /// <summary>
    /// Searches for hotel with specified parameters.
    /// </summary>
    /// <param name="address">The address of the hotel.</param>
    /// <returns>The found <see cref="Hotel"/> or <see langword="null"/> if none is found.</returns>
    public Task<Hotel?> GetHotel(string address);
}