using Core.Data.Repositories.Core;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    private readonly IRoomsRepository _roomsRepository;

    public AdminController(IRoomsRepository roomsRepository)
    {
        _roomsRepository = roomsRepository;
    }

    [HttpGet("add-room-modifiers")]
    public Task AddRoomModifiers()
    {
        return _roomsRepository.AddRoomModifiers();
    }
}