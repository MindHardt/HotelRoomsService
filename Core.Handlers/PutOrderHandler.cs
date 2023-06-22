using System.Net.Http.Json;
using Core.Entities;
using Core.Exceptions;
using Core.Requests;
using Core.Responses;
using Core.Services.Core;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Core.Handlers;

public class PutOrderHandler : IRequestHandler<PutOrderRequest, PutOrderResponse>
{
    private readonly HttpClient _httpClient;
    private readonly IRoomsService _roomsService;
    private readonly string _cleaningServiceUrl;

    public PutOrderHandler(HttpClient httpClient, IConfiguration configuration, IRoomsService roomsService)
    {
        _httpClient = httpClient;
        _roomsService = roomsService;
        _cleaningServiceUrl = configuration.GetSection("Urls")["CleaningService"]!;
    }
    
    
    public async Task<PutOrderResponse> Handle(PutOrderRequest request, CancellationToken cancellationToken)
    {
        var dbRoom =
            await _roomsService.GetByCoordinates(request.HotelLatitude, request.HotelLongitude, request.RoomNumber);
        
        NotFoundException.ThrowIfNull(dbRoom);
        var updateRoom = dbRoom with
        {
            State = RoomCleanState.Clean
        };
        await _roomsService.UpdateRoom(updateRoom);
        
        //await _httpClient.PostAsJsonAsync(_cleaningServiceUrl, request, cancellationToken: cancellationToken);
        return new PutOrderResponse();
    }
}