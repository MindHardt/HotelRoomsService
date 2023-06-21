using Core.Entities;

namespace Core.Requests;

public class PostOrderRequest
{
    public HotelCoordinates HotelCoordinates { get; set; }
    public int RoomNumber { get; set; }
}