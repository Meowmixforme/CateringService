using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Venues.Data;
using ThAmCo.Venues.DTOs;

namespace ThAmCo.Venues.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypesController : ControllerBase
    {
        private readonly VenuesDbContext _context;

        public EventTypesController(VenuesDbContext context)
        {
            _context = context;
        }

        // GET: api/EventTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventTypeDTO>>> GetEventTypes()
        {
            var dto = await _context.EventTypes
                .Select(e => new EventTypeDTO
                {
                    Id = e.Id,
                    Title = e.Title
                })
                .ToListAsync();
            return Ok(dto);
        }
    }
}