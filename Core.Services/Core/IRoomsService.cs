using Core.Entities;

namespace Core.Services.Core;

public interface IRoomsService
{
    public Task<IReadOnlyCollection<Room>> GetAllRoomsAsync(float hotelLatitude, float hotelLongitude);
    public Task<Room?> GetByCoordinates(float hotelLatitude, float hotelLongitude, int number);
    public Task<Room?> UpdateRoom(Room room);
}
