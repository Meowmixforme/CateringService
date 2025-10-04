using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;
using ThAmCo.Events.DTOs;

namespace ThAmCo.Events.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestBookingsController : ControllerBase
    {
        private readonly EventsContext _context;

        public GuestBookingsController(EventsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestBookingDTO>>> GetGuestBookings()
        {
            return await _context.GuestBookings
                .Select(gb => new GuestBookingDTO
                {
                    EventId = gb.EventId,
                    GuestId = gb.GuestId,
                    Attended = gb.Attended
                })
                .ToListAsync();
        }

        [HttpGet("{eventId}/{guestId}")]
        public async Task<ActionResult<GuestBookingDTO>> GetGuestBooking(int eventId, int guestId)
        {
            var gb = await _context.GuestBookings
                .FirstOrDefaultAsync(x => x.EventId == eventId && x.GuestId == guestId);
            if (gb == null) return NotFound();

            return new GuestBookingDTO
            {
                EventId = gb.EventId,
                GuestId = gb.GuestId,
                Attended = gb.Attended
            };
        }

        [HttpPost]
        public async Task<ActionResult<GuestBookingDTO>> CreateGuestBooking(GuestBookingDTO dto)
        {
            var entity = new GuestBooking
            {
                EventId = dto.EventId,
                GuestId = dto.GuestId,
                Attended = dto.Attended
            };

            _context.GuestBookings.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGuestBooking), new { eventId = entity.EventId, guestId = entity.GuestId }, dto);
        }

        [HttpPut("{eventId}/{guestId}")]
        public async Task<IActionResult> UpdateGuestBooking(int eventId, int guestId, GuestBookingDTO dto)
        {
            if (eventId != dto.EventId || guestId != dto.GuestId) return BadRequest();

            var entity = await _context.GuestBookings
                .FirstOrDefaultAsync(x => x.EventId == eventId && x.GuestId == guestId);
            if (entity == null) return NotFound();

            entity.Attended = dto.Attended;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{eventId}/{guestId}")]
        public async Task<IActionResult> DeleteGuestBooking(int eventId, int guestId)
        {
            var entity = await _context.GuestBookings
                .FirstOrDefaultAsync(x => x.EventId == eventId && x.GuestId == guestId);
            if (entity == null) return NotFound();

            _context.GuestBookings.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}