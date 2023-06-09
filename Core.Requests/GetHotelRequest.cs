using Core.Responses;
using MediatR;

namespace Core.Requests;

public record GetHotelRequest : IRequest<GetHotelResponse>
{
    public long? Id { get; set; }
    public string? Address { get; set; }
}