using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;
using MyPortpolio.Data;

namespace MyPortfolio.Controllers
{
    public class ManageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manage
        public async Task<IActionResult> Index()
        {
            return View(await _context.Manages.ToListAsync());
        }

        // GET: Manage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manages = await _context.Manages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manages == null)
            {
                return NotFound();
            }

            return View(manages);
        }

        // GET: Manage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Category,Subject,Contents,RegDate")] Manages manages)
        {
            if (ModelState.IsValid)
            {
                manages.RegDate = DateTime.Now;
                _context.Add(manages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manages);
        }

        // GET: Manage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manages = await _context.Manages.FindAsync(id);
            if (manages == null)
            {
                return NotFound();
            }
            return View(manages);
        }

        // POST: Manage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Category,Subject,Contents,RegDate")] Manages manages)
        {
            if (id != manages.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagesExists(manages.Id))
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
            return View(manages);
        }

        // GET: Manage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manages = await _context.Manages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manages == null)
            {
                return NotFound();
            }

            return View(manages);
        }

        // POST: Manage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manages = await _context.Manages.FindAsync(id);
            _context.Manages.Remove(manages);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagesExists(int id)
        {
            return _context.Manages.Any(e => e.Id == id);
        }
    }
}
