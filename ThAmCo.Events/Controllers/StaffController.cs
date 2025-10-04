using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;
using ThAmCo.Events.DTOs;

namespace ThAmCo.Events.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly EventsContext _context;

        public StaffController(EventsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffDTO>>> GetStaff()
        {
            return await _context.Staff
                .Select(s => new StaffDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    Role = s.Role,
                    FirstAidQualified = s.FirstAidQulaified
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StaffDTO>> GetStaff(int id)
        {
            var s = await _context.Staff.FindAsync(id);
            if (s == null) return NotFound();

            return new StaffDTO
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Role = s.Role,
                FirstAidQualified = s.FirstAidQulaified
            };
        }

        [HttpPost]
        public async Task<ActionResult<StaffDTO>> CreateStaff(StaffDTO dto)
        {
            var entity = new Staff
            {
                Name = dto.Name,
                Email = dto.Email,
                Role = dto.Role,
                FirstAidQulaified = dto.FirstAidQualified
            };

            _context.Staff.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return CreatedAtAction(nameof(GetStaff), new { id = entity.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaff(int id, StaffDTO dto)
        {
            if (id != dto.Id) return BadRequest();

            var entity = await _context.Staff.FindAsync(id);
            if (entity == null) return NotFound();

            entity.Name = dto.Name;
            entity.Email = dto.Email;
            entity.Role = dto.Role;
            entity.FirstAidQulaified = dto.FirstAidQualified;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var entity = await _context.Staff.FindAsync(id);
            if (entity == null) return NotFound();

            _context.Staff.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}