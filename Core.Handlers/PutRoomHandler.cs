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
    private readonly IMapper _mapper;

    public PutRoomHandler(IRoomsService roomsService, IMapper mapper)
    {
        _roomsService = roomsService;
        _mapper = mapper;
    }

    public async Task<PutRoomResponse> Handle(PutRoomRequest request, CancellationToken cancellationToken)
    {
        var updatedRoom = await _roomsService.UpdateRoom(_mapper.Map<Room>(request.Room));

        NotFoundException.ThrowIfNull(updatedRoom);

        //todo: отправить ченить клинингу

        var response = new PutRoomResponse();

        return response;
    }
}
