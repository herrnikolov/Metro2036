using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Metro2036.Data;
using Metro2036.Models;

namespace Metro2036.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TravelLogsController : Controller
    {
        private readonly Metro2036DbContext _context;

        public TravelLogsController(Metro2036DbContext context)
        {
            _context = context;
        }

        // GET: Admin/TravelLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TravelLogs.ToListAsync());
        }

        // GET: Admin/TravelLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelLog = await _context.TravelLogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travelLog == null)
            {
                return NotFound();
            }

            return View(travelLog);
        }

        // GET: Admin/TravelLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TravelLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TravelCardId,UserName,StationId,StationName")] TravelLog travelLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(travelLog);
        }

        // GET: Admin/TravelLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelLog = await _context.TravelLogs.FindAsync(id);
            if (travelLog == null)
            {
                return NotFound();
            }
            return View(travelLog);
        }

        // POST: Admin/TravelLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TravelCardId,UserName,StationId,StationName")] TravelLog travelLog)
        {
            if (id != travelLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelLogExists(travelLog.Id))
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
            return View(travelLog);
        }

        // GET: Admin/TravelLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelLog = await _context.TravelLogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travelLog == null)
            {
                return NotFound();
            }

            return View(travelLog);
        }

        // POST: Admin/TravelLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelLog = await _context.TravelLogs.FindAsync(id);
            _context.TravelLogs.Remove(travelLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelLogExists(int id)
        {
            return _context.TravelLogs.Any(e => e.Id == id);
        }
    }
}
