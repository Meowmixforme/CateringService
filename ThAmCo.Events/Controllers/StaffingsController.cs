using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Controllers
{
    public class StaffingsController : Controller
    {
        private readonly EventsContext _context;

        public StaffingsController(EventsContext context)
        {
            _context = context;
        }
        // General get request to return a list of staff
        // GET: Staffings
        public async Task<IActionResult> Index()
        {
            var eventsContext = _context.Staffing
                .Include(s => s.Event)
                .Include(s => s.Staff);
            return View(await eventsContext.ToListAsync());
        }
        //Get request for a specific staff member by id
        // GET: Staffings/Details/5
        public async Task<IActionResult> Details(int? id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return NotFound();
            }

            var staffing = await _context.Staffing
                .Include(s => s.Event)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.StaffId == id && m.EventId == id2);
            if (staffing == null)
            {
                return NotFound();
            }

            return View(staffing);
        }
        
        // GET: Staffings/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Title");
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Name");
            return View();
        }
        //Post request to edit a staff member
        // POST: Staffings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,EventId")] Staffing staffing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", staffing.EventId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Name", staffing.StaffId);
            return View(staffing);
        }

        // GET: Staffings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Staffing == null)
            {
                return NotFound();
            }

            var staffing = await _context.Staffing.FindAsync(id);
            if (staffing == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Text", staffing.EventId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Name", staffing.StaffId);
            return View(staffing);
        }



        // GET: Staffings/Delete/5
        public async Task<IActionResult> Delete(int? id, int? id2)
        {
            if (id == null || _context.Staffing == null)
            {
                return NotFound();
            }

            var staffing = await _context.Staffing
                .Include(s => s.Event)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.StaffId == id && m.EventId == id2);
            if (staffing == null)
            {
                return NotFound();
            }

            return View(staffing);
        }

        // POST: Staffings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Staffing == null)
            {
                return Problem("Entity set 'EventsContext.Staffing'  is null.");
            }
            var staffing = await _context.Staffing.FindAsync(id);
            if (staffing != null)
            {
                _context.Staffing.Remove(staffing);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // Check to see if staff and event are already bound
        private bool StaffingExists(int id, int id2)
        {
          return _context.Staffing.Any(e => e.StaffId == id && e.EventId == id2);
        }
    }
}
