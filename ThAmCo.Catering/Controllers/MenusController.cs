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
            var menus = await _context.Menus
                .Include(m => m.FoodItems)
                    .ThenInclude(mf => mf.FoodItem)
                .Select(m => new MenuDTO
                {
                    MenuId = m.MenuId,
                    MenuName = m.MenuName,
                    FoodItems = m.FoodItems
                        .Select(mf => new FoodItemDTO
                        {
                            FoodItemId = mf.FoodItem.FoodItemId,
                            Description = mf.FoodItem.Description,
                            UnitPrice = mf.FoodItem.UnitPrice
                        })
                        .ToList()
                })
                .ToListAsync();

            return Ok(menus);
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuDTO>> GetMenu(int id)
        {
            var menu = await _context.Menus
                .Include(m => m.FoodItems)
                    .ThenInclude(mf => mf.FoodItem)
                .FirstOrDefaultAsync(m => m.MenuId == id);

            if (menu == null)
            {
                return NotFound();
            }

            var dto = new MenuDTO
            {
                MenuId = menu.MenuId,
                MenuName = menu.MenuName,
                FoodItems = menu.FoodItems
                    .Select(mf => new FoodItemDTO
                    {
                        FoodItemId = mf.FoodItem.FoodItemId,
                        Description = mf.FoodItem.Description,
                        UnitPrice = mf.FoodItem.UnitPrice
                    })
                    .ToList()
            };

            return Ok(dto);
        }

        // PUT: api/Menus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu(int id, PutMenuDTO dto)
        {
            if (id != dto.MenuId)
            {
                return BadRequest();
            }

            var menu = await _context.Menus.FindAsync(id);

            if (menu == null)
            {
                return NotFound();
            }

            menu.MenuName = dto.MenuName;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Menus
        [HttpPost]
        public async Task<ActionResult<MenuDTO>> PostMenu(PostMenuDTO createMenuItem)
        {
            var menu = new Menu
            {
                MenuName = createMenuItem.MenuName
            };

            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();

            var dto = new MenuDTO
            {
                MenuId = menu.MenuId,
                MenuName = menu.MenuName,
                FoodItems = new List<FoodItemDTO>() // Empty on creation
            };

            return CreatedAtAction(nameof(GetMenu), new { id = menu.MenuId }, dto);
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
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