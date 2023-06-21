using Core.Entities;
using Core.Models;
using Core.Responses;
using MediatR;

namespace Core.Requests;

public record PutRoomRequest : IRequest<PutRoomResponse>
{
    public required float HotelLatitude { get; set; }
    public required float HotelLongitude { get; set; }
    public required RoomModel Room { get; set; }
}
