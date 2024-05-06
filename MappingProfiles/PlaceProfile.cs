using AutoMapper;
using TicketsBookingApp.Entities;
using TicketsBookingApp.Models.Place;

namespace TicketsBookingApp.MappingProfiles
{
    public class PlaceProfile : Profile
    {
        public PlaceProfile()
        {
            CreateMap<Place, PlaceDto>();

            CreateMap<PlaceForCreateDto, Place>();
        }
    }
}
