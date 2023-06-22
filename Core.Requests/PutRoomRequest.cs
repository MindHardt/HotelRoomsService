using Core.Entities;
using Core.Responses;
using MediatR;

namespace Core.Requests;

public record PutRoomRequest : IRequest<PutRoomResponse>
{
	public int? Number { get; set; }
	public RoomCleanState? State { get; set; }
}