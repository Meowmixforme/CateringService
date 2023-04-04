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
    public class GuestBookingsController : Controller
    {
        private readonly EventsContext _context;

        public GuestBookingsController(EventsContext context)
        {
            _context = context;
        }
        //Get request for a specific user by id
        // GET: GuestBookings/5
        public async Task<IActionResult> Index(int? id)
        {
            var eventsContext = _context.GuestBookings
                .Include(g => g.Event)
                .Include(g => g.Guest)
                .AsQueryable();

            if (id.HasValue)
            {
                eventsContext = eventsContext.Where(e => e.EventId == id);
            }

            return View(await eventsContext.ToListAsync());
        }
        //Get request to list details of a user and events they are part of
        // GET: GuestBookings/Details/5
        public async Task<IActionResult> Details(int? id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return NotFound();
            }

            var guestBooking = await _context.GuestBookings
                .Include(g => g.Guest)
                .Include(g => g.Event)
                .FirstOrDefaultAsync(m => m.GuestId == id && m.EventId == id2);
            if (guestBooking == null)
            {
                return NotFound();
            }

            return View(guestBooking);
        }

        // GET: GuestBookings/Create
        public IActionResult Create()
        {
            ViewData["GuestId"] = new SelectList(_context.Guests, "Id", "Email");
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Title");
            return View();
        }
        //Post request to add a booking
        // POST: GuestBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuestId,EventId,Attended")] GuestBooking guestBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guestBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            ViewData["GuestId"] = new SelectList(_context.Guests, "Id", "Email", guestBooking.GuestId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Title", guestBooking.EventId);

            return View(guestBooking);
        }
        //Post request to edit a booking
        // GET: GuestBookings/Edit/5
        public async Task<IActionResult> Edit(int? id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return NotFound();
            }

            var guestBooking = await _context.GuestBookings.FindAsync(id, id2);
            if (guestBooking == null)
            {
                return NotFound();
            }
            ViewData["GuestId"] = new SelectList(_context.GuestBookings, "Id", "Email", guestBooking.GuestId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Title", guestBooking.EventId);
            return View(guestBooking);
        }
        //Post request to edit a specific booking
        // POST: GuestBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuestId,EventId,Attended")] GuestBooking guestBooking)
        {
            if (id != guestBooking.GuestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guestBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestBookingExists(guestBooking.GuestId, guestBooking.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuestId"] = new SelectList(_context.GuestBookings, "Id", "Email", guestBooking.GuestId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Title", guestBooking.EventId);
            return View(guestBooking);
        }
        
        // GET: GuestBookings/Delete/5?5
        public async Task<IActionResult> Delete(int? id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return NotFound();
            }

            var guestBooking = await _context.GuestBookings
                .Include(g => g.Guest)
                .Include(g => g.Event)
                .FirstOrDefaultAsync(m => m.GuestId == id && m.EventId == id2);

            if (guestBooking == null)
            {
                return NotFound();
            }

            return View(guestBooking);
        }
        //Post request to delete a guest from their booking
        // POST: GuestBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("GuestId,EventId")] GuestBooking guestBooking)
        {
            guestBooking = await _context.GuestBookings
                .Include(g => g.Guest)
                .Include(g => g.Event)
                .FirstOrDefaultAsync(m => m.GuestId == id);

            _context.GuestBookings.Remove(guestBooking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestBookingExists(int id, int id2)
        {
            return _context.GuestBookings.Any(e => e.GuestId == id && e.EventId == id2);
        }
    }
}

