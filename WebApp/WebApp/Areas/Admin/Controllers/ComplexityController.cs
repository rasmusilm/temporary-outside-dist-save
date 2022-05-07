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
    public class ComplexityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComplexityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Complexity
        public async Task<IActionResult> Index()
        {
            return View(await _context.Complexities.ToListAsync());
        }

        // GET: Admin/Complexity/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complexity = await _context.Complexities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (complexity == null)
            {
                return NotFound();
            }

            return View(complexity);
        }

        // GET: Admin/Complexity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Complexity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Complexity complexity)
        {
            if (ModelState.IsValid)
            {
                complexity.Id = Guid.NewGuid();
                _context.Add(complexity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(complexity);
        }

        // GET: Admin/Complexity/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complexity = await _context.Complexities.FindAsync(id);
            if (complexity == null)
            {
                return NotFound();
            }
            return View(complexity);
        }

        // POST: Admin/Complexity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Complexity complexity)
        {
            if (id != complexity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(complexity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplexityExists(complexity.Id))
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
            return View(complexity);
        }

        // GET: Admin/Complexity/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complexity = await _context.Complexities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (complexity == null)
            {
                return NotFound();
            }

            return View(complexity);
        }

        // POST: Admin/Complexity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var complexity = await _context.Complexities.FindAsync(id);
            _context.Complexities.Remove(complexity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComplexityExists(Guid id)
        {
            return _context.Complexities.Any(e => e.Id == id);
        }
    }
}
