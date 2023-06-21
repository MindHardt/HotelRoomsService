using AutoMapper;
using Core.Entities;
using Core.Models;

namespace Core.Mappers;

public class HotelsMapper : Profile
{
    public HotelsMapper()
    {
        CreateMap<Room, RoomModel>();
        CreateMap<RoomModel, Room>();
        CreateMap<Hotel, HotelModel>();
    }
}