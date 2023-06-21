using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using Core.Models;
using Core.Requests;
using Core.Responses;
using Core.Services.Core;
using MediatR;

namespace Core.Handlers;

public class GetRoomPricesHandler : IRequestHandler<GetRoomPricesRequest, GetRoomPricesResponse>
{
    private readonly IHotelsService _hotelsService;
    private readonly IMapper _mapper;

    public GetRoomPricesHandler(
        IHotelsService hotelsService, 
        IMapper mapper)
    {
        _hotelsService = hotelsService;
        _mapper = mapper;
    }

    public async Task<GetRoomPricesResponse> Handle(GetRoomPricesRequest request, CancellationToken cancellationToken)
    {
        var allHotelsRoomPrices = new List<RoomPricesModel?>();
        foreach (var coordinate in request.Coordinates)
        {
            var minPrice = await _hotelsService.GetMinRoomPriceAsync(coordinate.Latitude, coordinate.Longitude);
            var maxPrice = await _hotelsService.GetMaxRoomPriceAsync(coordinate.Latitude, coordinate.Longitude);
            if(minPrice is null || maxPrice is null)
                continue;
            allHotelsRoomPrices.Add(new RoomPricesModel
            {
                Latitude = coordinate.Latitude,
                Longitude = coordinate.Longitude,
                MinPrice = (decimal)minPrice,
                MaxPrice = (decimal)maxPrice
            });
        }
        
        var response = new GetRoomPricesResponse()
        {
            RoomPrices = allHotelsRoomPrices
                .Select(_mapper.Map<RoomPricesModel>)
                .ToArray()
        };
        return response;
    }
}