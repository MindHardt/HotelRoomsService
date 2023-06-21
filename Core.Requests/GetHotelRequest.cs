using Core.Responses;
using MediatR;

namespace Core.Requests;

public record GetHotelRequest : IRequest<GetHotelResponse>
{
    public required float HotelLatitude { get; set; } 
    public required float HotelLongitude { get; set; } 
}