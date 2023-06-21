using Core.Models;

namespace Core.Responses;

public class GetRoomPricesResponse
{
    public required RoomPricesModel[] RoomPrices { get; set; }
}