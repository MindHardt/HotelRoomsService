using AutoMapper;
using Core.Entities;
using Core.Models;

namespace Core.Mappers;

public class HotelsMapper : Profile
{
    public HotelsMapper()
    {
        CreateMap<Room, RoomModel>()
            .ForMember(dest => dest.Modifiers,
                opt =>
                    opt.MapFrom(src => src.RoomModifiers.Select(m => m.Name)));
        CreateMap<HotelData, HotelModel>();
    }
}