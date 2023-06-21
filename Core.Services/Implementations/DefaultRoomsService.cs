using Core.Data.Repositories.Core;
using Core.Entities;
using Core.Services.Core;
using Core.Services.DI;

namespace Core.Services.Implementations;

[DefaultService]
public class DefaultRoomsService : IRoomsService
{
    private readonly IRoomsRepository _roomsRepository;

    public DefaultRoomsService(IRoomsRepository roomsRepository)
    {
        _roomsRepository = roomsRepository;
    }

    public Task<IReadOnlyCollection<Room>> GetAllRoomsAsync(float hotelLatitude, float hotelLongitude)
    {
        return _roomsRepository.GetAllRooms(hotelLatitude, hotelLongitude);
    }

    public async Task<Room?> GetByCoordinates(float hotelLatitude, float hotelLongitude, int number)
    {
        return await _roomsRepository.GetRoom(hotelLatitude, hotelLongitude, number);
    }

    public async Task<Room?> UpdateRoom(Room room)
    {
        return await _roomsRepository.UpdateRoom(room);
    }
}
