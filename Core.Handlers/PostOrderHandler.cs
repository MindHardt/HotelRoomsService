using System.Net.Http.Json;
using Core.Requests;
using Core.Responses;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Core.Handlers;

public class PostOrderHandler : IRequestHandler<PostOrderRequest, PostOrderResponse>
{
    private readonly HttpClient _httpClient;
    private readonly string _cleaningServiceUrl;

    public PostOrderHandler(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _cleaningServiceUrl = configuration.GetSection("Urls")["CleaningService"]!;

    }
    
    //TODO Сделать сохранение что комната грязная в бд
    public async Task<PostOrderResponse> Handle(PostOrderRequest request, CancellationToken cancellationToken)
    {

        await _httpClient.PostAsJsonAsync(_cleaningServiceUrl, request, cancellationToken: cancellationToken);
        return new PostOrderResponse();
    }
}