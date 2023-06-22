using System.Buffers.Text;

namespace Core.Entities;

public record Room
{
    public required int Number { get; set; }
    
    public required long HotelId { get; set; }
    public required Hotel Hotel { get; set; }

    public RoomCleanState State { get; set; } = RoomCleanState.Clean;
    
    public required RoomClass Class { get; set; }
    
    public required decimal Price { get; set; }
    
    public required string ImageUrl { get; set; } 

    public required int Floor { get; set; }

    //public required RoomRoomModifier[] Modifiers { get; set; }
    public ICollection<RoomModifier> RoomModifiers { get; set; } = new List<RoomModifier>();
}