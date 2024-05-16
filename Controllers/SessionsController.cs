using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TicketsBookingApp.Entities;
using TicketsBookingApp.Entities.UnitOfWork;
using TicketsBookingApp.Models.Session;

namespace TicketsBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SessionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("time_test")]
        public ActionResult<DateTime> Test()
        {
            return DateTime.Now;
        }

        [HttpGet("cinema/{cinemaId}")]
        public async Task<ActionResult<SessionDto>> List(
            int cinemaId, [FromQuery] int pageNum = 1, [FromQuery] int pageSize = 3)
        {
            var sessions = await _unitOfWork.SessionRepository
                .ListAsync(pageNum, pageSize, cinemaId);

            var sessionDtos = new List<SessionDto>();

            foreach (var session in sessions)
            {
                sessionDtos.Add(_mapper.Map<SessionDto>(session));
            }

            return Ok(sessionDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SessionDto>> GetById(int id)
        {
            var session = await _unitOfWork.SessionRepository
                .GetByIdAsync(id);

            if (session == null) return NotFound(nameof(id));

            return _mapper.Map<SessionDto>(session);
        }

        [HttpPost]
        public async Task<ActionResult<SessionDto>> Create(
            SessionForCreateDto sessionForCreateDto)
        {
            var session = _mapper.Map<Session>(sessionForCreateDto);

            _unitOfWork.SessionRepository.Add(session);

            await _unitOfWork.SaveChangesAsync();

            var createdSession = await _unitOfWork.SessionRepository
                .GetByIdAsync(session.Id);

            if (createdSession == null) return NotFound(nameof(createdSession));

            return CreatedAtAction(nameof(GetById), new
            {
                session.Id,
            },
            _mapper.Map<SessionDto>(createdSession));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(
            int id, JsonPatchDocument patchDocument)
        {
            var session = await _unitOfWork.SessionRepository
                .GetByIdAsync(id);

            if (session == null) return NotFound(nameof(session));

            if (patchDocument.Operations
                .Where(o =>
                    o.path.StartsWith("Film")
                    || o.path.StartsWith("Hall")
                    || o.path.StartsWith("Tickets"))
                .Any())
            {
                return BadRequest(
                    "You are trying to change Tickets, Film or Hall inside of Session.");
            }

            patchDocument.ApplyTo(session);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var session = await _unitOfWork.SessionRepository
                .GetByIdAsync(id);

            if (session == null) return NotFound(nameof(id));

            _unitOfWork.SessionRepository.Delete(session);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
