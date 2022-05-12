using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Server_v0._0.Models;

namespace Server_v0._0.Controllers
{
    public class WorkDonesController : Controller
    {
        private readonly ApplicationContext _context;

        public WorkDonesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: WorkDones
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.WorkDones.Include(w => w.Route);
            return View(await applicationContext.ToListAsync());
        }

        // GET: WorkDones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workDone = await _context.WorkDones
                .Include(w => w.Route)
                .FirstOrDefaultAsync(m => m.WorkDoneId == id);
            if (workDone == null)
            {
                return NotFound();
            }

            return View(workDone);
        }

        // GET: WorkDones/Create
        public IActionResult Create()
        {
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId");
            return View();
        }

        // POST: WorkDones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkDoneId,DepartureDate,ReturnDate,RouteId")] WorkDone workDone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workDone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId", workDone.RouteId);
            return View(workDone);
        }

        // GET: WorkDones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workDone = await _context.WorkDones.FindAsync(id);
            if (workDone == null)
            {
                return NotFound();
            }
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId", workDone.RouteId);
            return View(workDone);
        }

        // POST: WorkDones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkDoneId,DepartureDate,ReturnDate,RouteId")] WorkDone workDone)
        {
            if (id != workDone.WorkDoneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workDone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkDoneExists(workDone.WorkDoneId))
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
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId", workDone.RouteId);
            return View(workDone);
        }

        // GET: WorkDones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workDone = await _context.WorkDones
                .Include(w => w.Route)
                .FirstOrDefaultAsync(m => m.WorkDoneId == id);
            if (workDone == null)
            {
                return NotFound();
            }

            return View(workDone);
        }

        // POST: WorkDones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workDone = await _context.WorkDones.FindAsync(id);
            _context.WorkDones.Remove(workDone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkDoneExists(int id)
        {
            return _context.WorkDones.Any(e => e.WorkDoneId == id);
        }
    }
}
