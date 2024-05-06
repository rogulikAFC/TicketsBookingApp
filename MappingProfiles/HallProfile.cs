using AutoMapper;
using TicketsBookingApp.Entities;
using TicketsBookingApp.Models.Hall;

namespace TicketsBookingApp.MappingProfiles
{
    public class HallProfile : Profile
    {
        public HallProfile()
        {
            CreateMap<Hall, HallDto>()
                .AfterMap((src, dest) => 
                    dest.AlignPlaces = src.AlignPlaces?.Value ?? "end");

            CreateMap<HallForCreateDto, Hall>()
                .ForMember(src => src.AlignPlaces, opt => opt.Ignore());
        }
    }
}
