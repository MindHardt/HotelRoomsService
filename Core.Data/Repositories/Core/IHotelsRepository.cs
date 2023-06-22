using Core.Entities;

namespace Core.Data.Repositories.Core;

public interface IHotelsRepository
{
    /// <summary>
    /// Gets all the hotels without their rooms for overview.
    /// </summary>
    /// <returns></returns>
    public Task<IReadOnlyCollection<HotelData>> GetAllHotels();

    /// <summary>
    /// Searches for hotel with specified parameters.
    /// </summary>
    /// <param name="lat"></param>
    /// <param name="lon"></param>
    /// <returns>The found <see cref="Hotel"/> or <see langword="null"/> if none is found.</returns>
    public Task<HotelData?> GetHotel(float lat, float lon);
   }