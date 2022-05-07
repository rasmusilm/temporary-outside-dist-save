#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Domain;
using App.DAL.EF;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DifficultyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DifficultyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Difficulty
        public async Task<IActionResult> Index()
        {
            return View(await _context.Difficulties.ToListAsync());
        }

        // GET: Admin/Difficulty/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var difficulty = await _context.Difficulties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (difficulty == null)
            {
                return NotFound();
            }

            return View(difficulty);
        }

        // GET: Admin/Difficulty/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Difficulty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Difficulty difficulty)
        {
            if (ModelState.IsValid)
            {
                difficulty.Id = Guid.NewGuid();
                _context.Add(difficulty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(difficulty);
        }

        // GET: Admin/Difficulty/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var difficulty = await _context.Difficulties.FindAsync(id);
            if (difficulty == null)
            {
                return NotFound();
            }
            return View(difficulty);
        }

        // POST: Admin/Difficulty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Difficulty difficulty)
        {
            if (id != difficulty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(difficulty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DifficultyExists(difficulty.Id))
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
            return View(difficulty);
        }

        // GET: Admin/Difficulty/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var difficulty = await _context.Difficulties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (difficulty == null)
            {
                return NotFound();
            }

            return View(difficulty);
        }

        // POST: Admin/Difficulty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var difficulty = await _context.Difficulties.FindAsync(id);
            _context.Difficulties.Remove(difficulty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DifficultyExists(Guid id)
        {
            return _context.Difficulties.Any(e => e.Id == id);
        }
    }
}
