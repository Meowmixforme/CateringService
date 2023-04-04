using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


            var Fooditem = await _context
                .FoodItems

                //Project them into the DTO shape
                .Select(f => new FoodItemDTO
                {
                    FoodItemId = f.FoodItemId,
                    Description = f.Description,
                    UnitPrice = f.UnitPrice,
                    
                    


                })
                .ToListAsync();

            if (GetFoodItems == null)
            {
                return NotFound();
            }
            return Ok(Fooditem);
        }

        // GET: api/FoodItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodItemDTO>> GetFoodItem(int id)
        {

            var foodItem = await _context
            .FoodItems
            .FirstOrDefaultAsync(m => m.FoodItemId == id);

            if (foodItem == null)
            {
                return NotFound();
            }

            //Project them into the DTO shape
            ThAmCo.Catering.DTOs.FoodItemDTO dto = new DTOs.FoodItemDTO();
            dto.FoodItemId = id;
            dto.Description = foodItem.Description;
            dto.UnitPrice = foodItem.UnitPrice;
            



            // return them
            return Ok(dto);

        }

        // PUT: api/FoodItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<FoodItemDTO>> PutFoodItem(int id, FoodItemDTO FoodItemDTO)

        {

            if (id != FoodItemDTO.FoodItemId)
            {
                return BadRequest();
            }

            var foodItem = await _context
            .FoodItems
            .FirstOrDefaultAsync(m => m.FoodItemId == id);
            //Project them into the entity to server from DTO
            {
                foodItem.Description = FoodItemDTO.Description;
                foodItem.UnitPrice = FoodItemDTO.UnitPrice!;
                
            };


            await _context.SaveChangesAsync();

            return Ok();
        }


        // POST: api/FoodItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodItemDTO>> PostFoodItem(FoodItemDTO createFoodItem)

        {   //Project them into the entity to server from DTO
            var foodItem = new FoodItem
            {
                Description = createFoodItem.Description,
                UnitPrice = createFoodItem.UnitPrice,

            };

            _context.FoodItems.Add(foodItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodItem", new { id = foodItem.FoodItemId }, foodItem);
        }

        // DELETE: api/FoodItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuDTO>> DeleteFoodItem(int id)
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
