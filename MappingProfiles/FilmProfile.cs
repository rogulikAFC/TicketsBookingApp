using AutoMapper;
using TicketsBookingApp.Entities;
using TicketsBookingApp.Models.Film;

namespace TicketsBookingApp.MappingProfiles
{
    public class FilmProfile : Profile
    {
        public FilmProfile()
        {
            CreateMap<Film, FilmDto>()
                .AfterMap((src, dest) => dest.AgeLimit = src.AgeLimit?.Value);

            CreateMap<FilmForCreateDto, Film>();
        }
    }
}
