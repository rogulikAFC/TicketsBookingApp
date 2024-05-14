using AutoMapper;
using TicketsBookingApp.Entities;
using TicketsBookingApp.Models.Session;

namespace TicketsBookingApp.MappingProfiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<SessionForCreateDto, Session>();

            CreateMap<Session, SessionDto>();
        }
    }
}
