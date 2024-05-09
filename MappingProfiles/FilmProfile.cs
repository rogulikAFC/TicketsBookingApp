using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using TicketsBookingApp.Entities;
using TicketsBookingApp.Models.Film;

namespace TicketsBookingApp.MappingProfiles
{
    public class FilmProfile : Profile
    {
        public FilmProfile()
        {
            CreateMap<Film, FilmDto>()
                .ForMember(dest => dest.AgeLimit,
                    opt => opt.MapFrom(src => src.AgeLimit!.Value));

            CreateMap<FilmForCreateDto, Film>()
                .ForMember(src => src.AgeLimit, opt => opt.Ignore());
        }
    }
}
