using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;
using ThAmCo.Events.DTOs;

namespace ThAmCo.Events.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffingsController : ControllerBase
    {
        private readonly EventsContext _context;

        public StaffingsController(EventsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffingDTO>>> GetStaffings()
        {
            return await _context.Staffing
                .Select(s => new StaffingDTO
                {
                    StaffId = s.StaffId,
                    EventId = s.EventId
                })
                .ToListAsync();
        }

        [HttpGet("{staffId}/{eventId}")]
        public async Task<ActionResult<StaffingDTO>> GetStaffing(int staffId, int eventId)
        {
            var s = await _context.Staffing
                .FirstOrDefaultAsync(x => x.StaffId == staffId && x.EventId == eventId);
            if (s == null) return NotFound();

            return new StaffingDTO
            {
                StaffId = s.StaffId,
                EventId = s.EventId
            };
        }

        [HttpPost]
        public async Task<ActionResult<StaffingDTO>> CreateStaffing(StaffingDTO dto)
        {
            var entity = new Staffing
            {
                StaffId = dto.StaffId,
                EventId = dto.EventId
            };

            _context.Staffing.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStaffing), new { staffId = entity.StaffId, eventId = entity.EventId }, dto);
        }

        [HttpDelete("{staffId}/{eventId}")]
        public async Task<IActionResult> DeleteStaffing(int staffId, int eventId)
        {
            var entity = await _context.Staffing
                .FirstOrDefaultAsync(x => x.StaffId == staffId && x.EventId == eventId);
            if (entity == null) return NotFound();

            _context.Staffing.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}