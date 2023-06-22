using Core.Models;

namespace Core.Responses;

public record PutRoomResponse
{
	public required RoomModel Room { get; set; }
}