using Core.Entities;

namespace Core.Models;

public record RoomModel
{
    public required RoomClass Class { get; set; }
    public required decimal Price { get; set; }
    public required int Number { get; set; }
    public required RoomCleanState State { get; set; }
    public required string ImageUrl { get; set; }
    public required int Floor { get; set; }
    public required string[] Modifiers { get; set; }
}