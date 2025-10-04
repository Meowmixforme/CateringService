using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;
using ThAmCo.Events.DTOs;

namespace ThAmCo.Events.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {
        private readonly EventsContext _context;

        public GuestsController(EventsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestDTO>>> GetGuests()
        {
            return await _context.Guests
                .Select(g => new GuestDTO
                {
                    Id = g.Id,
                    Forename = g.Forename,
                    Surname = g.Surname,
                    Payment = g.Payment,
                    EmailAddress = g.EmailAddress,
                    Deleted = g.Deleted
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuestDTO>> GetGuest(int id)
        {
            var g = await _context.Guests.FindAsync(id);
            if (g == null) return NotFound();

            return new GuestDTO
            {
                Id = g.Id,
                Forename = g.Forename,
                Surname = g.Surname,
                Payment = g.Payment,
                EmailAddress = g.EmailAddress,
                Deleted = g.Deleted
            };
        }

        [HttpPost]
        public async Task<ActionResult<GuestDTO>> CreateGuest(GuestDTO dto)
        {
            var entity = new Guest
            {
                Forename = dto.Forename,
                Surname = dto.Surname,
                Payment = dto.Payment,
                EmailAddress = dto.EmailAddress,
                Deleted = dto.Deleted
            };

            _context.Guests.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return CreatedAtAction(nameof(GetGuest), new { id = entity.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuest(int id, GuestDTO dto)
        {
            if (id != dto.Id) return BadRequest();

            var entity = await _context.Guests.FindAsync(id);
            if (entity == null) return NotFound();

            entity.Forename = dto.Forename;
            entity.Surname = dto.Surname;
            entity.Payment = dto.Payment;
            entity.EmailAddress = dto.EmailAddress;
            entity.Deleted = dto.Deleted;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var entity = await _context.Guests.FindAsync(id);
            if (entity == null) return NotFound();

            _context.Guests.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}