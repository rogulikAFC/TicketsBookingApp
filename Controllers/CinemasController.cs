using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TicketsBookingApp.Entities;
using TicketsBookingApp.Entities.UnitOfWork;
using TicketsBookingApp.Models.Cinema;

namespace TicketsBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CinemasController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));

            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/Cinemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CinemaDto>>> List(
            [FromQuery] int pageNum, [FromQuery] int pageSize)
        {
            var cinemaEntities = await _unitOfWork.CinemaRepository
                .ListAsync(pageNum, pageSize);

            var cinemaDtos = new List<CinemaDto>();

            foreach (var cinemaEntity in cinemaEntities)
            {
                cinemaDtos.Add(_mapper.Map<CinemaDto>(cinemaEntity));
            }

            return cinemaDtos;
        }

        // GET: api/Cinemas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CinemaDto?>> GetById(int id)
        {
            var cinema = await _unitOfWork.CinemaRepository
                .GetByIdAsync(id);

            if (cinema == null) return NotFound(nameof(id));

            return _mapper.Map<CinemaDto>(cinema);
        }

        // POST: api/Cinemas
        [HttpPost]
        public async Task<ActionResult<CinemaDto?>> Create(
            CinemaForCreateDto cinemaForCreateDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaForCreateDto);

            _unitOfWork.CinemaRepository.Add(cinema);

            await _unitOfWork.SaveChangesAsync();

            var createdCinema = await _unitOfWork.CinemaRepository
                .GetByIdAsync(cinema.Id);

            if (createdCinema == null) return NotFound(nameof(createdCinema));

            var createdCinemaDto = _mapper.Map<CinemaDto>(createdCinema);

            return CreatedAtAction(nameof(GetById), new
            {
                cinema.Id,
            },
            createdCinemaDto);
        }

        // PATCH: api/Cinemas/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(
            int id, JsonPatchDocument patchDocument)
        {
            var cinemaForChange = await _unitOfWork.CinemaRepository
                .GetByIdAsync(id);

            if (cinemaForChange == null) return NotFound(nameof(id));

            patchDocument.ApplyTo(cinemaForChange);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Cinemas/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cinema = await _unitOfWork.CinemaRepository
                .GetByIdAsync(id);

            if (cinema == null) return NotFound(nameof(cinema));

            _unitOfWork.CinemaRepository.Delete(cinema);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
