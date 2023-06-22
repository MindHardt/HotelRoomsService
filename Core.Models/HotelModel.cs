namespace Core.Models;

public record HotelModel
{
    public required float Latitude { get; set; }
    public required float Longitude { get; set; }
    public decimal? MaxPrice { get; set; }
    public decimal? MinPrice { get; set; }
    public required RoomModel[] Rooms { get; set; }
}