using Core.Models;
using Core.Responses;
using MediatR;

namespace Core.Requests;

public class GetRoomPricesRequest : IRequest<GetRoomPricesResponse>
{
    public required CoordinatesModel[] Coordinates { get; set; }
}