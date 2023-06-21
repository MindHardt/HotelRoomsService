using Core.Entities;
using Core.Responses;
using MediatR;

namespace Core.Requests;

public class PostOrderRequest : IRequest<PostOrderResponse>
{
    public required float HotelLatitude { get; set; } 
    public required float HotelLongitude { get; set; } 
    public required int RoomNumber { get; set; }
}