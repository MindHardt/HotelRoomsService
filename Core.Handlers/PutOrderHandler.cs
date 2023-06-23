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

        RoomCleanState state = request.State;
        if (request.IsCleaningRequested is false || state is RoomCleanState.Clean)
        {
            try
            {
                var cleaningRequest = new
                {
                    latitude = request.HotelLatitude,
                    longitude = request.HotelLongitude,
                    room_number = request.RoomNumber
                };
                var response = await _httpClient.PostAsJsonAsync(_cleaningServiceUrl, cleaningRequest, cancellationToken: cancellationToken);
                state = response.IsSuccessStatusCode ? RoomCleanState.CleanRequested : RoomCleanState.Dirty;
            }
            catch (Exception e)
            {
                state = RoomCleanState.Dirty;
            }
        }
        
        var updateRoom = dbRoom with
        {
            State = state
        };
        
        await _roomsService.UpdateRoom(updateRoom);
        
        return new PutOrderResponse() {CleaningState = updateRoom.State };
    }
}
