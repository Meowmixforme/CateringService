using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Venues.Data;
using ThAmCo.Venues.DTOs;

namespace ThAmCo.Venues.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly VenuesDbContext _context;

        public ReservationsController(VenuesDbContext context)
        {
            _context = context;
        }

        [HttpGet("{reference}")]
        public async Task<ActionResult<ReservationDTO>> GetReservation([FromRoute] string reference)
        {
            var reservation = await _context.Reservations.FindAsync(reference);
            if (reservation == null)
                return NotFound();

            // Map Reservation to ReservationDTO
            var dto = new ReservationDTO
            {
                Reference = reservation.Reference,
                EventDate = reservation.EventDate,
                VenueCode = reservation.VenueCode,
                WhenMade = reservation.WhenMade,
                StaffId = reservation.StaffId
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<ReservationDTO>> CreateReservation([FromBody] ReservationPostDTO reservationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var availability = await _context.Availabilities
                .Include(a => a.Reservation)
                .FirstOrDefaultAsync(
                    a => a.Date == reservationDto.EventDate
                        && a.VenueCode == reservationDto.VenueCode);

            if (availability == null || availability.Reservation != null)
                return BadRequest("Venue is not available on the requested date.");

            var reservation = new Reservation
            {
                Reference = $"{availability.VenueCode}{availability.Date:yyyyMMdd}",
                EventDate = availability.Date,
                VenueCode = availability.VenueCode,
                WhenMade = DateTime.Now,
                StaffId = reservationDto.StaffId
            };

            availability.Reservation = reservation;
            await _context.SaveChangesAsync();

            var dto = new ReservationDTO
            {
                Reference = reservation.Reference,
                EventDate = reservation.EventDate,
                VenueCode = reservation.VenueCode,
                WhenMade = reservation.WhenMade,
                StaffId = reservation.StaffId
            };

            return CreatedAtAction("GetReservation",
                new { reference = reservation.Reference },
                dto);
        }

        [HttpDelete("{reference}")]
        public async Task<ActionResult<ReservationDTO>> DeleteReservation([FromRoute] string reference)
        {
            var reservation = await _context.Reservations.FindAsync(reference);
            if (reservation == null)
                return NotFound();

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            var dto = new ReservationDTO
            {
                Reference = reservation.Reference,
                EventDate = reservation.EventDate,
                VenueCode = reservation.VenueCode,
                WhenMade = reservation.WhenMade,
                StaffId = reservation.StaffId
            };
            return Ok(dto);
        }
    }
}