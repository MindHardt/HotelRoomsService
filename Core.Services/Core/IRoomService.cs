
using Core.Entities;

namespace Core.Services.Core;

public interface IRoomService
{
	public Task<Room?> PutByStateAsync(RoomCleanState state);
}