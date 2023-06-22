namespace Core.Entities;

public record RoomModifier
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}
