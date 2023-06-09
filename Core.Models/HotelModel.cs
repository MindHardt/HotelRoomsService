namespace Core.Models;

public record HotelModel
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required RoomModel[] Rooms { get; set; }
}