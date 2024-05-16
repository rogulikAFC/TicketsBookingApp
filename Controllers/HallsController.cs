using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TicketsBookingApp.Entities;
using TicketsBookingApp.Entities.UnitOfWork;
using TicketsBookingApp.Models.Hall;

namespace TicketsBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly TicketsBookingAppDbContext _context;
        private readonly ILogger<HallsController> _logger;

        public HallsController(
            IUnitOfWork unitOfWork, IMapper mapper, TicketsBookingAppDbContext context,
            ILogger<HallsController> logger)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));

            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));

            _context = context
                ?? throw new ArgumentNullException(nameof(context));

            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));

        }

        // GET: api/Halls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HallDto>>> List(
            [FromQuery] int pageSize = 3, [FromQuery] int pageNum = 1)
        {
            var halls = await _unitOfWork.HallRepository
                .ListAsync(pageNum, pageSize);

            var hallDtos = new List<HallDto>();

            foreach (var hall in halls)
            {
                hallDtos.Add(_mapper.Map<HallDto>(hall));
            }

            return Ok(hallDtos);
        }

        // GET: api/Halls/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<HallDto?>> GetById(int id)
        {
            var hall = await _unitOfWork.HallRepository
                .GetByIdAsync(id);

            if (hall == null) return NotFound(nameof(id));

            var hallDto = _mapper.Map<HallDto>(hall);

            return Ok(hallDto);
        }

        // POST: api/Halls
        [HttpPost]
        public async Task<ActionResult<HallDto>> Create(
            HallForCreateDto hallForCreateDto)
        {
            var hall = _mapper.Map<Hall>(hallForCreateDto);

            _unitOfWork.HallRepository.Add(hall);

            var alignPlaces = await _context.AlignPlaces
                .FirstOrDefaultAsync(ap => ap.Value == hallForCreateDto.AlignPlaces);

            if (alignPlaces == null) return NotFound(nameof(hallForCreateDto.AlignPlaces));

            hall.AlignPlacesId = alignPlaces.Id;

            await _unitOfWork.SaveChangesAsync();

            var createdHall = await _unitOfWork.HallRepository
                .GetByIdAsync(hall.Id);

            if (createdHall == null) return NotFound(nameof(createdHall.Id));

            var places = new List<Place>();
            
            foreach (var placeForCreateDto in hall.Places)
            {
                var place = _mapper.Map<Place>(placeForCreateDto);

                place.HallId = createdHall.Id;

                places.Add(place);
            }

            await _unitOfWork.SaveChangesAsync();

            var createdHallDto = _mapper.Map<HallDto>(createdHall);

            return CreatedAtAction(nameof(GetById), new
            {
                hall.Id,
            },
            createdHallDto);
        }

        // PATCH: api/Halls/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> Change(
            JsonPatchDocument patchDocument, int id)
        {
            var hall = await _unitOfWork.HallRepository
                .GetByIdAsync(id);

            if (hall == null) return NotFound(nameof(id));

            patchDocument.ApplyTo(hall);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Halls/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var hall = await _unitOfWork.HallRepository
                .GetByIdAsync(id);

            if (hall == null) return NotFound(nameof(hall));

            _unitOfWork.HallRepository
                .Delete(hall);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
