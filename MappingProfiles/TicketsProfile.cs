using AutoMapper;
using TicketsBookingApp.Entities;
using TicketsBookingApp.Models.Tickets;

namespace TicketsBookingApp.MappingProfiles
{
    public class TicketsProfile : Profile
    {
        public TicketsProfile()
        {
            CreateMap<TicketForCreateDto, Ticket>();
            
            CreateMap<Ticket, TicketDto>()
                .AfterMap((s, d) => d.Session.Hall.Places = [])
                .AfterMap((s, d) => d.Place.IsBooked = true);
        }
    }
}
