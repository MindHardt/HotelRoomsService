using Core.Entities;
using Core.Responses;
using MediatR;

namespace Core.Requests;

public record PutOrderRequest : IRequest<PutOrderResponse>
{
    public required float HotelLatitude { get; set; }
    public required float HotelLongitude { get; set; }
    public required int Number { get; set; }
    public required RoomCleanState State { get; set; }
}
