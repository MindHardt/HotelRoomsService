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
    /// <param name="lat"></param>
    /// <param name="lon"></param>
    /// <returns>The found <see cref="Hotel"/> or <see langword="null"/> if none is found.</returns>
    public Task<Hotel?> GetHotel(float lat, float lon);

    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lat"></param>
    /// <param name="lon"></param>
    /// <returns></returns>
    public Task<decimal?> GetMinRoomPrices(float lat, float lon);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lat"></param>
    /// <param name="lon"></param>
    /// <returns></returns>
    public Task<decimal?> GetMaxRoomPrices(float lat, float lon);

}