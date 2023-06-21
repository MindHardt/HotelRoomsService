using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public record Hotel
{
    public long Id { get; set; }
    
    [MaxLength(64)]
    public required string Name { get; set; }
    
    [MaxLength(256)]
    public required string Address { get; set; }

    public ICollection<Room> Rooms { get; set; } = new List<Room>();

    public HotelCoordinates Coordinates { get; set; } = new (0, 0);
}