using Core.Entities;

namespace Core.Data.Repositories.Core;

public interface IRoomsRepository
{
	/// <summary>
	/// Searches for hotel with specified parameters.
	/// </summary>
	/// <param name="state">The state of the room.</param>
	/// <returns>The found <see cref="Room"/> or <see langword="null"/> if none is found.</returns>
	public Task<Room?> PutRoom(RoomCleanState state);
}