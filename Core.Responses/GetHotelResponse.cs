using Core.Models;

namespace Core.Responses;

public record GetHotelResponse
{
    public required HotelModel Hotel { get; set; }
}