using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TicketsBookingApp.Entities;
using TicketsBookingApp.Entities.UnitOfWork;
using TicketsBookingApp.Models.Film;

namespace TicketsBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly TicketsBookingAppDbContext _dbContext;
        private readonly ILogger<FilmsController> _logger;

        public FilmsController(
            IUnitOfWork unitOfWork, IMapper mapper, TicketsBookingAppDbContext dbContext,
            ILogger<FilmsController> logger)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));

            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));

            _dbContext = dbContext
                ?? throw new ArgumentNullException(nameof(dbContext));

            _logger = logger;

        }

        // GET: api/Films?{pageNum}&{pageSize}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmDto>>> List(
            [FromQuery] int pageNum = 1, [FromQuery] int pageSize = 3)
        {
            var films = await _unitOfWork.FilmRepository
                .ListAsync(pageNum, pageSize);

            var filmDtos = new List<FilmDto>();

            foreach (var film in films)
            {
                filmDtos.Add(_mapper.Map<FilmDto>(film));
            }

            return filmDtos;
        }

        // GET: api/Films/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmDto?>> GetById(int id)
        {
            var film = await _unitOfWork.FilmRepository
                .GetByIdAsync(id);

            if (film == null) return NotFound(nameof(film));

            return _mapper.Map<FilmDto>(film);
        }

        // POST: api/Films
        [HttpPost]
        public async Task<ActionResult<FilmDto?>> Create(
            FilmForCreateDto filmForCreateDto)
        {
            var ageLimit = _dbContext.AgeLimits
                .FirstOrDefault(al => al.Value == filmForCreateDto.AgeLimit);

            if (ageLimit == null) return NotFound(nameof(filmForCreateDto.AgeLimit));

            var film = _mapper.Map<Film>(filmForCreateDto);

            film.AgeLimitId = ageLimit.Id;

            _unitOfWork.FilmRepository.Add(film);

            await _unitOfWork.SaveChangesAsync();

            var createdFilm = await _unitOfWork.FilmRepository
                .GetByIdAsync(film.Id);

            if (createdFilm == null) return NotFound(nameof(createdFilm.Id));

            var createdFilmDto = _mapper.Map<FilmDto>(createdFilm);

            return CreatedAtAction(nameof(GetById), new
            {
                createdFilmDto.Id
            },
            createdFilmDto);
        }

        // PATCH: api/Films/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(
            int id, JsonPatchDocument patchDocument)
        {
            var film = await _unitOfWork.FilmRepository
                .GetByIdAsync(id);

            if (film == null) return NotFound(nameof(id));

            var ageLimitOperationFromPatchDocument = patchDocument.Operations.FirstOrDefault(
                pd => pd.path == "ageLimit");

            var ageLimitValueFromPatchDocument = int.Parse(JsonConvert.SerializeObject(
                ageLimitOperationFromPatchDocument?.value));

            patchDocument.Operations.Remove(ageLimitOperationFromPatchDocument);

            if (ageLimitOperationFromPatchDocument != null)
            {
                var ageLimit = await _dbContext.AgeLimits
                    .FirstOrDefaultAsync(al => al.Value == ageLimitValueFromPatchDocument);

                if (ageLimit == null) return NotFound(nameof(ageLimit));

                film.AgeLimitId = ageLimit.Id;
            }

            patchDocument.ApplyTo(film);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Films/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var film = await _unitOfWork.FilmRepository
                .GetByIdAsync(id);

            if (film == null) return NotFound(nameof(id));

            _unitOfWork.FilmRepository
                .Delete(film);

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
