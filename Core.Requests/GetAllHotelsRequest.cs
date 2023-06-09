using Core.Responses;
using MediatR;

namespace Core.Requests;

public record GetAllHotelsRequest : IRequest<GetAllHotelsResponse>
{
}