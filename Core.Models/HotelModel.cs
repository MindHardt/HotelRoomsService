namespace Core.Models;

public record HotelModel
{
    public required float Latitude { get; set; }
    public required float Longitude { get; set; }
    public required RoomModel[] Rooms { get; set; }
}