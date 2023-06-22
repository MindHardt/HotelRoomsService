using AutoMapper;
using Core.Models;
using Core.Requests;
using Core.Responses;
using Core.Services.Core;
using MediatR;

namespace Core.Handlers;

public class GetAllHotelsHandler : IRequestHandler<GetAllHotelsRequest, GetAllHotelsResponse>
{
    private readonly IHotelsService _hotelsService;
    private readonly IMapper _mapper;

    public GetAllHotelsHandler(
        IHotelsService hotelsService, 
        IMapper mapper)
    {
        _hotelsService = hotelsService;
        _mapper = mapper;
    }

    public async Task<GetAllHotelsResponse> Handle(GetAllHotelsRequest request, CancellationToken cancellationToken)
    {
        var hotels = await _hotelsService.GetAllHotelsAsync();

        var response = new GetAllHotelsResponse
        {
            Hotels = hotels
                .Select(_mapper.Map<HotelModel>)
                .ToArray()
        };
        return response;
    }
}