using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using Core.Models;
using Core.Requests;
using Core.Responses;
using Core.Services.Core;
using MediatR;

namespace Core.Handlers;

public class PutOrderHandler : IRequestHandler<PutOrderRequest, PutOrderResponse>
{
    private readonly IRoomsService _roomsService;

    public PutOrderHandler(IRoomsService roomsService)
    {
        _roomsService = roomsService;
    }

    public async Task<PutOrderResponse> Handle(PutOrderRequest request, CancellationToken cancellationToken)
    {
        var dbRoom =
            await _roomsService.GetByCoordinates(request.HotelLatitude, request.HotelLongitude, request.Number);
        
        NotFoundException.ThrowIfNull(dbRoom);

        var updatedRoom = dbRoom with // record'ы умеют вот так
        {
            State = request.State
        }; // Обновляем только те поля которые могут измениться (номер и отель не могут)
        
        await _roomsService.UpdateRoom(updatedRoom);

        var response = new PutOrderResponse();

        return response;
    }
}
