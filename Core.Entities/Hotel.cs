using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public record Hotel
{
    public long Id { get; set; }

    public ICollection<Room> Rooms { get; set; } = new List<Room>();

    public float Latitude { get; set; }
    
    public float Longitude { get; set; }
} 