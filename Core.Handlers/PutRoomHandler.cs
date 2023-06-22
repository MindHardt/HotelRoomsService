using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using Core.Models;
using Core.Requests;
using Core.Responses;
using Core.Services.Core;
using MediatR;

namespace Core.Handlers;

public class PutRoomHandler : IRequestHandler<PutRoomRequest, PutRoomResponse>
{
    private readonly IRoomsService _roomsService;

    public PutRoomHandler(IRoomsService roomsService)
    {
        _roomsService = roomsService;
    }

    public async Task<PutRoomResponse> Handle(PutRoomRequest request, CancellationToken cancellationToken)
    {
        var dbRoom =
            await _roomsService.GetByCoordinates(request.HotelLatitude, request.HotelLongitude, request.Room.Number);
        
        NotFoundException.ThrowIfNull(dbRoom);

        var updatedRoom = dbRoom with
        {
            Class = request.Room.Class,
            Floor = request.Room.Floor,
            State = request.Room.State,
            ImageUrl = request.Room.ImageUrl,
            Price = request.Room.Price,
        };
        
        await _roomsService.UpdateRoom(updatedRoom);

        //todo: отправить ченить клинингу

        var response = new PutRoomResponse();

        return response;
    }
}
