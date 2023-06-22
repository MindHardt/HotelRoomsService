using System.Net.Mime;
using Core.Entities;
using Core.Requests;
using Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class HotelsController : ControllerBase
{
    private readonly IMediator _mediator;

    public HotelsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all")]
    public Task<GetAllHotelsResponse> GetAllHotels([FromQuery] GetAllHotelsRequest request)
        => _mediator.Send(request);
    
    [HttpGet]
    public Task<GetHotelResponse> GetHotel([FromQuery] GetHotelRequest request)
        => _mediator.Send(request);

    [HttpPut("room")]
    public Task<PutRoomResponse> UpdateRoom([FromBody] PutRoomRequest request)
    => _mediator.Send(request);
    
    [HttpPut("room/{State}")]
    public Task<PutOrderResponse> MakeRoomClear([FromBody, FromRoute] PutOrderRequest request, RoomCleanState State)
    {
        request.State = State;
        return _mediator.Send(request);
    }
}