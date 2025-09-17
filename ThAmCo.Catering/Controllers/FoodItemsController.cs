using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Catering.Data;
using ThAmCo.Catering.DTOs;

namespace ThAmCo.Catering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemsController : ControllerBase
    {
        private readonly CateringContext _context;

        public FoodItemsController(CateringContext context)
        {
            _context = context;
        }

        // GET: api/FoodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItemDTO>>> GetFoodItems()
        {
            var foodItems = await _context.FoodItems
                .Select(f => new FoodItemDTO
                {
                    FoodItemId = f.FoodItemId,
                    Description = f.Description,
                    UnitPrice = f.UnitPrice
                })
                .ToListAsync();

            return Ok(foodItems);
        }

        // GET: api/FoodItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodItemDTO>> GetFoodItem(int id)
        {
            var foodItem = await _context.FoodItems
                .FirstOrDefaultAsync(m => m.FoodItemId == id);

            if (foodItem == null)
            {
                return NotFound();
            }

            var dto = new FoodItemDTO
            {
                FoodItemId = foodItem.FoodItemId,
                Description = foodItem.Description,
                UnitPrice = foodItem.UnitPrice
            };

            return Ok(dto);
        }

        // PUT: api/FoodItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodItem(int id, FoodItemDTO foodItemDto)
        {
            if (id != foodItemDto.FoodItemId)
            {
                return BadRequest();
            }

            var foodItem = await _context.FoodItems.FindAsync(id);
            if (foodItem == null)
            {
                return NotFound();
            }

            foodItem.Description = foodItemDto.Description;
            foodItem.UnitPrice = foodItemDto.UnitPrice;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/FoodItems
        [HttpPost]
        public async Task<ActionResult<FoodItemDTO>> PostFoodItem(FoodItemDTO createFoodItem)
        {
            var foodItem = new FoodItem
            {
                Description = createFoodItem.Description,
                UnitPrice = createFoodItem.UnitPrice
            };

            _context.FoodItems.Add(foodItem);
            await _context.SaveChangesAsync();

            var dto = new FoodItemDTO
            {
                FoodItemId = foodItem.FoodItemId,
                Description = foodItem.Description,
                UnitPrice = foodItem.UnitPrice
            };

            return CreatedAtAction(nameof(GetFoodItem), new { id = foodItem.FoodItemId }, dto);
        }

        // DELETE: api/FoodItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodItem(int id)
        {
            var foodItem = await _context.FoodItems.FindAsync(id);
            if (foodItem == null)
            {
                return NotFound();
            }

            _context.FoodItems.Remove(foodItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodItemExists(int id)
        {
            return _context.FoodItems.Any(e => e.FoodItemId == id);
        }
    }
}