using AutoMapper;
using Core.Exceptions;
using Core.Models;
using Core.Requests;
using Core.Responses;
using Core.Services.Core;
using MediatR;

namespace Core.Handlers;

public class PutRoomHandler : IRequestHandler<PutRoomRequest, PutRoomResponse>
{
	private readonly IRoomService _roomsService;
	private readonly IMapper _mapper;

	public PutRoomHandler(
		IRoomService roomsService,
		IMapper mapper)
	{
		_roomsService = roomsService;
		_mapper = mapper;
	}

	public async Task<PutRoomResponse> Handle(PutRoomRequest request, CancellationToken cancellationToken)
	{
		var dbRoom = _roomsService.PutByStateAsync(request.State.Value);

		NotFoundException.ThrowIfNull(dbRoom);

		var response = new PutRoomResponse
		{
			Room = _mapper.Map<RoomModel>(dbRoom)
		};
		return response;
	}
}