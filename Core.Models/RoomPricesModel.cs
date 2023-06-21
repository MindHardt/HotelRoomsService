namespace Core.Models;

public class RoomPricesModel
{
    public required float Latitude { get; set; }
    public required float Longitude { get; set; }
    public required decimal MinPrice { get; set; }
    public required decimal MaxPrice { get; set; }
}
