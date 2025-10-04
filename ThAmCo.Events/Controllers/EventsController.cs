using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;
using ThAmCo.Events.DTOs;

namespace ThAmCo.Events.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventsContext _context;

        public EventsController(EventsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDTO>>> GetEvents()
        {
            return await _context.Events
                .Select(e => new EventDTO
                {
                    Id = e.Id,
                    Title = e.Title,
                    Duration = e.Duration,
                    Date = e.Date,
                    EventTypeId = e.EventTypeId,
                    Cancelled = e.Cancelled,
                    FoodBookingId = e.CateringMenu,
                    VenueReservationReference = e.VenueReservationReference
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDTO>> GetEvent(int id)
        {
            var e = await _context.Events.FindAsync(id);
            if (e == null) return NotFound();

            return new EventDTO
            {
                Id = e.Id,
                Title = e.Title,
                Duration = e.Duration,
                Date = e.Date,
                EventTypeId = e.EventTypeId,
                Cancelled = e.Cancelled,
                FoodBookingId = e.CateringMenu,
                VenueReservationReference = e.VenueReservationReference
            };
        }

        [HttpPost]
        public async Task<ActionResult<EventDTO>> CreateEvent(EventDTO dto)
        {
            var entity = new Event
            {
                Title = dto.Title,
                Duration = dto.Duration,
                Date = dto.Date,
                EventTypeId = dto.EventTypeId,
                CateringMenu = dto.FoodBookingId,
                VenueReservationReference = dto.VenueReservationReference
            };

            _context.Events.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return CreatedAtAction(nameof(GetEvent), new { id = entity.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, EventDTO dto)
        {
            if (id != dto.Id) return BadRequest();

            var entity = await _context.Events.FindAsync(id);
            if (entity == null) return NotFound();

            entity.Title = dto.Title;
            entity.Duration = dto.Duration;
            entity.Date = dto.Date;
            entity.EventTypeId = dto.EventTypeId;
            entity.CateringMenu = dto.FoodBookingId;
            entity.VenueReservationReference = dto.VenueReservationReference;
            entity.Cancelled = dto.Cancelled;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var entity = await _context.Events.FindAsync(id);
            if (entity == null) return NotFound();

            _context.Events.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}