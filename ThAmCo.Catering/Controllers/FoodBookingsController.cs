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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodBookingDTO>>> GetFoodBookings()
        {
           var foodBooking = await _context.FoodBookings

                .Include(foo => foo.Menu.FoodItems)
                .Select( foo => new FoodBookingDTO
                
                {
                    FoodBookingId = foo.FoodBookingId,
                    ClientReferenceId = foo.ClientReferenceId,
                    NumberOfGuests = foo.NumberOfGuests,
                    MenuId = foo.MenuId,
                    Menu = foo.Menu,
                    

                })

                .ToListAsync();

            if (foodBooking == null)
            {
                return NotFound();
            }

            return Ok(foodBooking);
        }

        // GET: api/FoodBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodBookingDTO>> GetFoodBooking(int id)
        {
            var foodBooking = await _context
            .FoodBookings
            .Include(m => m.MenuId)
            .FirstOrDefaultAsync(foo => foo.FoodBookingId == id);

            if (foodBooking == null)
            {
                return NotFound();
            }
            ThAmCo.Catering.DTOs.FoodBookingDTO dto = new DTOs.FoodBookingDTO();
            dto.FoodBookingId = id;
            dto.ClientReferenceId = foodBooking.ClientReferenceId;
            dto.NumberOfGuests = foodBooking.NumberOfGuests;
            dto.MenuId = foodBooking.MenuId;
            dto.Menu = foodBooking.Menu;
            

            // return them
            return Ok(dto);
        }

        // PUT: api/FoodBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        // look at book session/ trainer in part 2
        public async Task<ActionResult<CreateFoodBookingDTO>> PutFoodBooking(int id, CreateFoodBookingDTO foodBook)
        {
            var foodBooking = await _context.FoodBookings.FindAsync(id);

            if (id != foodBooking.FoodBookingId)
            {
                return BadRequest("FoodBooking already booked");
            }

            {
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
                    if (!FoodBookingExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return Ok();
        }

   


        // POST: api/FoodBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateFoodBookingDTO>> PostFoodBooking(CreateFoodBookingDTO foodBook)
        {
            var foodBooking = new FoodBooking
            {
                ClientReferenceId = foodBook.ClientReferenceId,
                NumberOfGuests = foodBook.NumberOfGuests,
                MenuId = foodBook.MenuId,
                


            };
                
            _context.FoodBookings.Add(foodBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodBooking", new { id = foodBooking.FoodBookingId }, foodBooking);
        }

 

        [HttpDelete("{id}")]
        public async Task<ActionResult<FoodBookingDTO>> DeleteFoodBooking(int id)
        {
            var foodBookingDTO = await _context.FoodBookings.FindAsync(id);
            if (foodBookingDTO == null)
            {
                return NotFound();
            }

            _context.FoodBookings.Remove(foodBookingDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        
    }

        private bool FoodBookingExists(int id)
        {
            return _context.FoodBookings.Any(e => e.FoodBookingId == id);
        }
    }
}
