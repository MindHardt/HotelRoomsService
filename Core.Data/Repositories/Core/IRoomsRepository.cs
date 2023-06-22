using Core.Entities;

namespace Core.Data.Repositories.Core;

public interface IRoomsRepository
{
    /// <summary>
    /// Gets all the rooms without their rooms for overview.
    /// </summary>
    /// <param name="lat">Hotel latitude</param>
    /// <param name="lon">Hotel longitude</param>
    /// <returns></returns>
    public Task<IReadOnlyCollection<Room>> GetAllRooms(float lat, float lon);

    /// <summary>
    /// Searches for room with specified parameters.
    /// </summary>
    /// <param name="lat">Hotel latitude</param>
    /// <param name="lon">Hotel longitude</param>
    /// <param name="number">Room number</param>
    /// <returns>The found <see cref="Room"/> or <see langword="null"/> if none is found.</returns>
    public Task<Room?> GetRoom(float lat, float lon, int number);

    /// <summary>
    /// Updates the room with the same number
    /// </summary>
    /// <param name="room">Sample for updating</param>
    /// <returns>Updated room or null if failed</returns>
    Task<Room?> UpdateRoom(Room room);
}