using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TicketsBookingApp.EmailService;
using TicketsBookingApp.Entities;
using TicketsBookingApp.Entities.UnitOfWork;
using TicketsBookingApp.Models.Tickets;

namespace TicketsBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public TicketsController(
            IUnitOfWork unitOfWork, IEmailService emailService, IMapper mapper)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));

            _emailService = emailService
                ?? throw new ArgumentNullException(nameof(emailService));

            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/Tickets?{phone}&{email}${isUsed}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDto>>> List([FromQuery] string? phone, [FromQuery] string? email, [FromQuery] bool? isUsed)
        {
            var tickets = await _unitOfWork.TicketRepository
                .ListAsync(phone, email, isUsed);

            var ticketDtos = new List<TicketDto>();

            foreach (var ticket in tickets)
            {
                ticketDtos.Add(_mapper.Map<TicketDto>(ticket));
            }

            return ticketDtos;
        }

        // GET: api/Tickets/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDto?>> GetById(int id)
        {
            var ticket = await _unitOfWork.TicketRepository
                .GetByIdAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return _mapper.Map<TicketDto>(ticket);
        }

        // POST: api/Tickets
        [HttpPost]
        public async Task<ActionResult<TicketDto?>> Create(
            TicketForCreateDto ticketForCreateDto)
        {
            var session = await _unitOfWork.SessionRepository
                .GetByIdAsync(ticketForCreateDto.SessionId);

            if (session == null)
            {
                return NotFound(nameof(ticketForCreateDto.SessionId));
            }

            var place = await _unitOfWork.PlaceRepository
                .GetByIdAsync(ticketForCreateDto.PlaceId);

            if (place == null)
            {
                return NotFound(nameof(ticketForCreateDto.PlaceId));
            }

            var placesWithStatusBySession = await _unitOfWork.PlaceRepository
                .PlacesWithStatusBySession(session);

            if (!placesWithStatusBySession.Select(p => p.Id).Contains(place.Id))
            {
                return BadRequest("Session's hall doesn't contains this place.");
            }

            if (placesWithStatusBySession.Where(p => p.IsBooked == true).Select(p => p.Id).Contains(place.Id))
            {
                return BadRequest("This place is already booked.");
            }

            var ticket = _mapper.Map<Ticket>(ticketForCreateDto);

            _unitOfWork.TicketRepository.Add(ticket);

            await _unitOfWork.SaveChangesAsync();

            var sessionTime = ticket.Session.DateAndTime;

            await _emailService.SendEmailAsync(ticket.Email,
                $"""
                You have booked the ticket to the "{ticket.Session.Film.Title}."
                """,

                $"""
                Session will be at {sessionTime.Day}.{sessionTime.Month}.{sessionTime.Year} {sessionTime.Hour}:{sessionTime.Minute} in cinema by address {ticket.Session.Hall.Cinema.Address}, hall {ticket.Session.HallId}.
                Ticket id is {ticket.Id}.
                """);

            var createdTicket = await _unitOfWork.TicketRepository
                .GetByIdAsync(ticket.Id);

            if (createdTicket == null)
            {
                return NotFound(createdTicket);
            }

            var createdTicketDto = _mapper.Map<TicketDto>(createdTicket);

            return CreatedAtAction(nameof(GetById), new
            {
                createdTicket.Id
            },
            createdTicketDto);
        }

        // GET: api/Tickets/{id}/use
        [HttpGet("{id}/use")]
        public async Task<ActionResult> UseTicket(int id)
        {
            var ticket = await _unitOfWork.TicketRepository
                .GetByIdAsync(id);

            if (ticket == null)
            {
                return NotFound(nameof(id));
            }

            if (ticket.IsUsed)
            {
                return BadRequest("Ticket is already used.");
            }

            ticket.IsUsed = true;

            await _unitOfWork.SaveChangesAsync();

            await _emailService.SendEmailAsync(ticket.Email, "You have used your ticket", "Wish you nice viewing!");

            return NoContent();
        }

        // DELETE: api/Tickets/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ticket = await _unitOfWork.TicketRepository
                .GetByIdAsync(id);

            if (ticket == null)
            {
                return NotFound(nameof(ticket));
            }

            _unitOfWork.TicketRepository.Delete(ticket);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
