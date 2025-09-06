using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Catering.Data;
using ThAmCo.Catering.DTOs;

namespace ThAmCo.Catering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodBookingsController : ControllerBase
    {
        private readonly CateringContext _context;

        public FoodBookingsController(CateringContext context)
        {
            _context = context;
        }

        // GET: api/FoodBookings
        /// <summary>
        /// Gets all food bookings, including menus and their food items.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodBookingDTO>>> GetFoodBookings()
        {
            var foodBookings = await _context.FoodBookings
                .Include(foo => foo.Menu)
                    .ThenInclude(menu => menu.FoodItems) // Properly include nested navigation property
                .Select(foo => new FoodBookingDTO
                {
                    FoodBookingId = foo.FoodBookingId,
                    ClientReferenceId = foo.ClientReferenceId,
                    NumberOfGuests = foo.NumberOfGuests,
                    MenuId = foo.MenuId,
                    Menu = foo.Menu // Assuming Menu is mapped as part of DTO
                })
                .ToListAsync();

            // foodBookings will never be null; ToListAsync returns an empty list if no results.
            return Ok(foodBookings);
        }

        // GET: api/FoodBookings/5
        /// <summary>
        /// Gets a single food booking by ID, including its menu and food items.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodBookingDTO>> GetFoodBooking(int id)
        {
            var foodBooking = await _context.FoodBookings
                .Include(foo => foo.Menu)
                    .ThenInclude(menu => menu.FoodItems)
                .FirstOrDefaultAsync(foo => foo.FoodBookingId == id);

            if (foodBooking == null)
            {
                return NotFound();
            }

            var dto = new FoodBookingDTO
            {
                FoodBookingId = foodBooking.FoodBookingId,
                ClientReferenceId = foodBooking.ClientReferenceId,
                NumberOfGuests = foodBooking.NumberOfGuests,
                MenuId = foodBooking.MenuId,
                Menu = foodBooking.Menu
            };

            return Ok(dto);
        }

        // PUT: api/FoodBookings/5
        /// <summary>
        /// Updates an existing food booking.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodBooking(int id, CreateFoodBookingDTO foodBook)
        {
            var foodBooking = await _context.FoodBookings.FindAsync(id);

            if (foodBooking == null)
            {
                return NotFound();
            }

            if (id != foodBooking.FoodBookingId)
            {
                return BadRequest("FoodBooking ID mismatch.");
            }

            // Update only allowed fields. Overposting protection.
            foodBooking.ClientReferenceId = foodBook.ClientReferenceId!;
            foodBooking.NumberOfGuests = foodBook.NumberOfGuests;
            foodBooking.MenuId = foodBook.MenuId;

            _context.Entry(foodBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Double check existence in case of concurrency issues
                if (!FoodBookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // No content is returned for a successful PUT update
            return NoContent();
        }

        // POST: api/FoodBookings
        /// <summary>
        /// Creates a new food booking.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<FoodBookingDTO>> PostFoodBooking(CreateFoodBookingDTO foodBook)
        {
            var foodBooking = new FoodBooking
            {
                ClientReferenceId = foodBook.ClientReferenceId,
                NumberOfGuests = foodBook.NumberOfGuests,
                MenuId = foodBook.MenuId
            };

            _context.FoodBookings.Add(foodBooking);
            await _context.SaveChangesAsync();

            // Prepare DTO for response
            var dto = new FoodBookingDTO
            {
                FoodBookingId = foodBooking.FoodBookingId,
                ClientReferenceId = foodBooking.ClientReferenceId,
                NumberOfGuests = foodBooking.NumberOfGuests,
                MenuId = foodBooking.MenuId,
                Menu = await _context.Menus
                    .Include(m => m.FoodItems)
                    .FirstOrDefaultAsync(m => m.MenuId == foodBooking.MenuId)
            };

            // Return the created booking using the standard REST pattern
            return CreatedAtAction(nameof(GetFoodBooking), new { id = dto.FoodBookingId }, dto);
        }

        // DELETE: api/FoodBookings/5
        /// <summary>
        /// Deletes a food booking by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodBooking(int id)
        {
            var foodBooking = await _context.FoodBookings.FindAsync(id);
            if (foodBooking == null)
            {
                return NotFound();
            }

            _context.FoodBookings.Remove(foodBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Checks whether a food booking exists by ID.
        /// </summary>
        private bool FoodBookingExists(int id)
        {
            return _context.FoodBookings.Any(e => e.FoodBookingId == id);
        }
    }
}