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
    public class MenuFoodItemsController : ControllerBase
    {
        private readonly CateringContext _context;

        public MenuFoodItemsController(CateringContext context)
        {
            _context = context;
        }

        // GET: api/MenuFoodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuFoodItemDTO>>> GetMenuFoodItems()
        {
            var menuFoodItems = await _context.MenuFoodItems
                .Select(mf => new MenuFoodItemDTO
                {
                    MenuId = mf.MenuId,
                    FoodItemId = mf.FoodItemId
                })
                .ToListAsync();

            return Ok(menuFoodItems);
        }

        // GET: api/MenuFoodItems/5/7
        [HttpGet("{menuId}/{foodItemId}")]
        public async Task<ActionResult<MenuFoodItemDTO>> GetMenuFoodItem(int menuId, int foodItemId)
        {
            var menuFoodItem = await _context.MenuFoodItems
                .FirstOrDefaultAsync(m => m.MenuId == menuId && m.FoodItemId == foodItemId);

            if (menuFoodItem == null)
                return NotFound();

            var dto = new MenuFoodItemDTO
            {
                MenuId = menuFoodItem.MenuId,
                FoodItemId = menuFoodItem.FoodItemId
            };
            return Ok(dto);
        }

        // PUT: api/MenuFoodItems/5/7
        [HttpPut("{menuId}/{foodItemId}")]
        public async Task<IActionResult> PutMenuFoodItem(int menuId, int foodItemId, PutMenuFoodItemDTO dto)
        {
            if (menuId != dto.MenuId || foodItemId != dto.FoodItemId)
                return BadRequest("ID mismatch.");

            var mfi = await _context.MenuFoodItems.FindAsync(menuId, foodItemId);
            if (mfi == null)
                return NotFound();

            // If there are updatable fields, update them here

            _context.Entry(mfi).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/MenuFoodItems
        [HttpPost]
        public async Task<ActionResult<MenuFoodItemDTO>> PostMenuFoodItem(MenuFoodItemDTO dto)
        {
            var menu = await _context.Menus.FindAsync(dto.MenuId);
            var foodItem = await _context.FoodItems.FindAsync(dto.FoodItemId);
            if (menu == null || foodItem == null)
                return NotFound();

            var mfi = new MenuFoodItem
            {
                MenuId = dto.MenuId,
                FoodItemId = dto.FoodItemId,
                Menu = menu,
                FoodItem = foodItem
            };

            _context.MenuFoodItems.Add(mfi);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMenuFoodItem), new { menuId = mfi.MenuId, foodItemId = mfi.FoodItemId }, dto);
        }

        // DELETE: api/MenuFoodItems/5/7
        [HttpDelete("{menuId}/{foodItemId}")]
        public async Task<IActionResult> DeleteMenuFoodItem(int menuId, int foodItemId)
        {
            var mfi = await _context.MenuFoodItems.FindAsync(menuId, foodItemId);
            if (mfi == null)
                return NotFound();

            _context.MenuFoodItems.Remove(mfi);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}