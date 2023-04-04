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
                .Include(m => m.Menu).Include(f => f.FoodItem)
                .Select(mf => new MenuFoodItemDTO
                //Project into DTO shape
                {
                    MenuId = mf.MenuId,
                    
                    FoodItemId = mf.FoodItemId,
                    
                })
                .ToListAsync();
            if (menuFoodItems == null)
            {
                return NotFound();
            }

            return Ok(menuFoodItems);
        }





        // GET: api/MenusFoodItems/5
        //[HttpGet("{MenuId}/FoodItemId/{FoodItemId}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuFoodItemDTO>> MenuFoodItem(int id)
        {
            var menuFoodItem = await _context
            .MenuFoodItems
            .Include(m => m.Menu).Include(f => f.FoodItem)
            .FirstOrDefaultAsync(m => m.MenuId == id);

            if (menuFoodItem == null)
            {
                return NotFound();
            }

            //Project them into the DTO shape
            ThAmCo.Catering.DTOs.MenuFoodItemDTO dto = new DTOs.MenuFoodItemDTO();
            dto.MenuId = id;
            
            dto.FoodItemId = menuFoodItem.FoodItemId;

            return Ok(dto);
        }




        // PUT: api/MenuFoodItems/5
        //[HttpPut("{MenuId}/FoodItemId/{FoodItemId}")]
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<PutMenuFoodItemDTO>> PutMenuFoodItem(int id, PutMenuFoodItemDTO menuFoodItemDTO)
        {

            if (id != menuFoodItemDTO.MenuId)
            {
                return BadRequest("menuFoodItem Does Not Exist!");
            }

            var menuFoodItem = await _context
            .MenuFoodItems
            .FirstOrDefaultAsync(m => m.MenuId == id);
            //Project from DTO into entity for server
            {
                menuFoodItemDTO.MenuId = menuFoodItem.MenuId;
                menuFoodItemDTO.FoodItemId = menuFoodItem.FoodItemId!;
            };

            _context.Entry(menuFoodItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }


        // POST: api/MenuFoodItems/5/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PutMenuFoodItemDTO>> PostMenuFoodItem(int menuId, int foodItemId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // 2 variables for menu & fooditem  
            var menu = await _context.Menus.FindAsync(menuId);
            var foodItem = await _context.FoodItems.FindAsync(foodItemId);
            if (menu == null || foodItem == null)
                return NotFound();
            //Project from DTO into entity 
            MenuFoodItem mfi = new MenuFoodItem()
            {
                FoodItemId = foodItemId,
                MenuId = menuId,
                FoodItem = foodItem,
                Menu = menu
            };

            await _context.MenuFoodItems.AddAsync(mfi);
            await _context.SaveChangesAsync();
            // Return as DTO
            return Ok(new PutMenuFoodItemDTO() { FoodItemId = mfi.FoodItemId, MenuId = mfi.MenuId });
        }





        // DELETE: api/MenuFoodItems/5/5
        [HttpDelete("{menuId}/{foodItemId}")]
        public async Task<ActionResult<MenuFoodItemDTO>> DeleteMenuFoodItem(int menuId, int foodItemId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var  mfi = await _context.MenuFoodItems.FindAsync(menuId, foodItemId);
            if (mfi == null)
                return NotFound();

            _context.MenuFoodItems.Remove(mfi);
            await _context.SaveChangesAsync();

            return Ok();

        }

        private bool MenuFoodItemExists(int id)
        {
            return _context.MenuFoodItems.Any(e => e.FoodItemId == id);
        }
    }
}
