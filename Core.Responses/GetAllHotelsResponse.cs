using Core.Models;

namespace Core.Responses;

public record GetAllHotelsResponse
{
    public required HotelModel[] Hotels { get; set; }
}