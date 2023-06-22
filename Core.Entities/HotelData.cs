namespace Core.Entities;

public record HotelData
{
    public ICollection<Room> Rooms { get; set; } = new List<Room>();
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public decimal MaxPrice { get; set; }
    public decimal MinPrice { get; set; }
}