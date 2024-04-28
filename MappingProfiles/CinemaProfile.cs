using AutoMapper;
using TicketsBookingApp.Entities;
using TicketsBookingApp.Models.Cinema;

namespace TicketsBookingApp.MappingProfiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<Cinema, CinemaDto>()
                .BeforeMap((src, dst) => dst.FullAddress = $"{src.City}, {src.Address}");

            CreateMap<CinemaForCreateDto, Cinema>();
        }
    }
}
