using Core.Entities;

namespace Core.Models;

public record RoomModel
{
    public required int Number { get; set; }
    public required RoomCleanState State { get; set; }
}