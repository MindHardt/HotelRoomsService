using System.Text.Json.Serialization;
using Core.Entities;
using Core.Responses;
using MediatR;

namespace Core.Requests;

public class PutOrderRequest : IRequest<PutOrderResponse>
{
    public required float HotelLatitude { get; set; } 
    public required float HotelLongitude { get; set; } 
    public required int RoomNumber { get; set; }
    public RoomCleanState State { get; set; }
    public required bool IsCleaningRequested { get; set; }
}