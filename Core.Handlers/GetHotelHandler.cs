using AutoMapper;
using Core.Exceptions;
using Core.Models;
using Core.Requests;
using Core.Responses;
using Core.Services.Core;
using MediatR;

namespace Core.Handlers;

public class GetHotelHandler : IRequestHandler<GetHotelRequest, GetHotelResponse>
{
    private readonly IHotelsService _hotelsService;
    private readonly IMapper _mapper;

    public GetHotelHandler(
        IHotelsService hotelsService, 
        IMapper mapper)
    {
        _hotelsService = hotelsService;
        _mapper = mapper;
    }

    public async Task<GetHotelResponse> Handle(GetHotelRequest request, CancellationToken cancellationToken)
    {
        var dbHotel = request.Id is null
            ? await _hotelsService.GetByAddressAsync(request.Address!)
            : await _hotelsService.GetByIdAsync(request.Id.Value);
        
        NotFoundException.ThrowIfNull(dbHotel);

        var response = new GetHotelResponse
        {
            Hotel = _mapper.Map<HotelModel>(dbHotel)
        };
        return response;
    }
}