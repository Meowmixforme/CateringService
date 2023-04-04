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
    public class MenusController : ControllerBase
    {
        private readonly CateringContext _context;

        public MenusController(CateringContext context)
        {
            _context = context;
        }

        // GET: api/Menus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuDTO>>> GetMenus()

       {

           var Menus = await _context
                .Menus
                
                .Include(f => f.FoodItems)
                .ThenInclude(f => f.FoodItem)

                .Select(f => new MenuDTO
                //Project them into the DTO shape
                {
                 MenuId = f.MenuId!,
                 MenuName = f.MenuName!,
                 FoodItems = f.FoodItems!,

              })
                  .ToListAsync();

            return Ok(Menus);

           // return await _context.Menus.ToListAsync();
        }

      
        // GET: api/Menus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuDTO>> GetMenu(int id)
        {
            List<MenuFoodItemDTO> FoodItem = new List<MenuFoodItemDTO>();

            //get the food items for this list
            var menu = await _context
            .Menus
            .Include(f => f.FoodItems)
            .ThenInclude(f => f.FoodItem)
            .FirstOrDefaultAsync(f => f.MenuId == id);


            if (menu == null)
            {
                return NotFound();
            }

            //Project them into the DTO shape
            ThAmCo.Catering.DTOs.MenuDTO dto = new DTOs.MenuDTO();
            dto.MenuId = id;
            dto.MenuName = menu.MenuName;
            dto.FoodItems = menu.FoodItems.ToList();
            // return them
            return Ok(dto);
        }

        

        // PUT: api/Menus/
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<PutMenuDTO>> PutMenuItem(int id, PutMenuDTO createMenuItem)
        {


            if (id != createMenuItem.MenuId)
            {
                return BadRequest();
            }

            var menu = await _context
                        .Menus
                        .FirstOrDefaultAsync(m => m.MenuId == id);

            {
                menu.MenuName = createMenuItem.MenuName!;
            };

            await _context.SaveChangesAsync();
            //Project from DTO into entity for server
            return Ok(new MenuDTO
            {
                MenuId = menu.MenuId,
                MenuName = menu.MenuName,
                

            });
        }

        // POST: api/Menus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostMenuDTO>> PostMenu(PostMenuDTO createMenuItem)
        { 

        var menu = new Menu
        {
            MenuName = createMenuItem.MenuName!,

         }; 
        
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostMenu", new { id = menu.MenuId }, menu);
        }



        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuDTO>> DeleteMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.MenuId == id);
        }
    }
}
