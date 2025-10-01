using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Venues.Data;
using ThAmCo.Venues.DTOs;

namespace ThAmCo.Venues.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private readonly VenuesDbContext _context;

        public AvailabilityController(VenuesDbContext context)
        {
            _context = context;
        }

        // GET: api/Availability?eventType=WED&beginDate=2022-11-01&endDate=2022-11-30
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvailabilityDTO>>> Get(
            [FromQuery] string eventType,
            [FromQuery] DateTime beginDate,
            [FromQuery] DateTime endDate)
        {
            var avails = await _context.Availabilities
                .Where(a => a.Reservation == null &&
                            a.Date >= beginDate.Date &&
                            a.Date <= endDate.Date)
                .Join(_context.Suitabilities.Where(s => s.EventTypeId == eventType),
                      a => a.VenueCode,
                      s => s.VenueCode,
                      (a, s) => a)
                .Include(a => a.Venue)
                .Select(a => new AvailabilityDTO
                {
                    Date = a.Date,
                    VenueCode = a.VenueCode,
                    CostPerHour = a.CostPerHour
                })
                .ToListAsync();

            return Ok(avails);
        }
    }
}
