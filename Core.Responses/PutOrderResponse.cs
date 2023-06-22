using Core.Entities;

namespace Core.Responses;

public class PutOrderResponse
{
    public required RoomCleanState CleaningState { get; set; }
}