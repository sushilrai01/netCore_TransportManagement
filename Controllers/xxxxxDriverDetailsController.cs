using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using netCoreTransportMgmt.Entity;

namespace netCoreTransportMgmt.Controllers
{
    public class xxxxxDriverDetailsController : Controller
    {
        private readonly TransportManagementContext _context;

        public xxxxxDriverDetailsController(TransportManagementContext context)
        {
            _context = context;
        }

        // GET: xxxxxDriverDetails
        public async Task<IActionResult> Index()
        {
            var transportManagementContext = _context.DriverDetails.Include(d => d.Route);
            return View(await transportManagementContext.ToListAsync());
        }

        // GET: xxxxxDriverDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DriverDetails == null)
            {
                return NotFound();
            }

            var driverDetail = await _context.DriverDetails
                .Include(d => d.Route)
                .FirstOrDefaultAsync(m => m.DriverId == id);
            if (driverDetail == null)
            {
                return NotFound();
            }

            return View(driverDetail);
        }

        // GET: xxxxxDriverDetails/Create
        public IActionResult Create()
        {
            ViewData["RouteId"] = new SelectList(_context.RouteDetails, "RouteId", "RouteId");
            return View();
        }

        // POST: xxxxxDriverDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DriverId,Name,ContactNo,DateAvailable,RouteId")] DriverDetail driverDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driverDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RouteId"] = new SelectList(_context.RouteDetails, "RouteId", "RouteId", driverDetail.RouteId);
            return View(driverDetail);
        }

        // GET: xxxxxDriverDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DriverDetails == null)
            {
                return NotFound();
            }

            var driverDetail = await _context.DriverDetails.FindAsync(id);
            if (driverDetail == null)
            {
                return NotFound();
            }
            ViewData["RouteId"] = new SelectList(_context.RouteDetails, "RouteId", "RouteId", driverDetail.RouteId);
            return View(driverDetail);
        }

        // POST: xxxxxDriverDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DriverId,Name,ContactNo,DateAvailable,RouteId")] DriverDetail driverDetail)
        {
            if (id != driverDetail.DriverId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driverDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverDetailExists(driverDetail.DriverId))
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
            ViewData["RouteId"] = new SelectList(_context.RouteDetails, "RouteId", "RouteId", driverDetail.RouteId);
            return View(driverDetail);
        }

        // GET: xxxxxDriverDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DriverDetails == null)
            {
                return NotFound();
            }

            var driverDetail = await _context.DriverDetails
                .Include(d => d.Route)
                .FirstOrDefaultAsync(m => m.DriverId == id);
            if (driverDetail == null)
            {
                return NotFound();
            }

            return View(driverDetail);
        }

        // POST: xxxxxDriverDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DriverDetails == null)
            {
                return Problem("Entity set 'TransportManagementContext.DriverDetails'  is null.");
            }
            var driverDetail = await _context.DriverDetails.FindAsync(id);
            if (driverDetail != null)
            {
                _context.DriverDetails.Remove(driverDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverDetailExists(int id)
        {
          return (_context.DriverDetails?.Any(e => e.DriverId == id)).GetValueOrDefault();
        }
    }
}
