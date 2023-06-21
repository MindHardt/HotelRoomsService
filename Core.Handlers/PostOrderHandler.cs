using System.Net;
using Newtonsoft.Json;

namespace Core.Handlers;

public class PostOrderHandler
{
    private readonly HttpClient _httpClient;

    public PostOrderHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https"); // TODO вписать корректного голубя (url-url)
    }

    public async Task<bool> RequestRoomCleaning(double latitude, double longitude, int roomNumber)
    {
        var request = new
        {
            hotel_coordinates = new
            {
                latitude,
                longitude
            },
            room_number = roomNumber
        };

        var requestBody = JsonConvert.SerializeObject(request);
        var content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("endpoint", content); // TODO Нужно будет укзать нужный эндпоинт у сервиса клининга
        return response.StatusCode == HttpStatusCode.OK;
    }
}