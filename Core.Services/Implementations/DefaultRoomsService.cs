using Core.Data.Repositories.Core;
using Core.Entities;
using Core.Services.Core;
using Core.Services.DI;

namespace Core.Services.Implementations;

[DefaultService]
public class DefaultRoomsService : IRoomService
{
	private readonly IRoomsRepository _roomsRepository;

	public DefaultRoomsService(IRoomsRepository roomsRepository)
	{
		_roomsRepository = roomsRepository;
	}

	public async Task<Room?> PutByStateAsync(RoomCleanState state)
	{
		return await _roomsRepository.PutRoom(state);
	}
}