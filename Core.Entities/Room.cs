namespace Core.Entities;

public record Room
{
    public required int Number { get; set; }
    
    public required long HotelId { get; set; }
    public required Hotel Hotel { get; set; }

    public RoomCleanState State { get; set; } = RoomCleanState.Clean;
    
}