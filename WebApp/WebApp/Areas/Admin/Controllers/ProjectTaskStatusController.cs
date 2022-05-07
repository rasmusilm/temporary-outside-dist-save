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
    public class ProjectTaskStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectTaskStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ProjectTaskStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProjectTaskStatus.ToListAsync());
        }

        // GET: Admin/ProjectTaskStatus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTaskStatus = await _context.ProjectTaskStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectTaskStatus == null)
            {
                return NotFound();
            }

            return View(projectTaskStatus);
        }

        // GET: Admin/ProjectTaskStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProjectTaskStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] ProjectTaskStatus projectTaskStatus)
        {
            if (ModelState.IsValid)
            {
                projectTaskStatus.Id = Guid.NewGuid();
                _context.Add(projectTaskStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectTaskStatus);
        }

        // GET: Admin/ProjectTaskStatus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTaskStatus = await _context.ProjectTaskStatus.FindAsync(id);
            if (projectTaskStatus == null)
            {
                return NotFound();
            }
            return View(projectTaskStatus);
        }

        // POST: Admin/ProjectTaskStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description")] ProjectTaskStatus projectTaskStatus)
        {
            if (id != projectTaskStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectTaskStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectTaskStatusExists(projectTaskStatus.Id))
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
            return View(projectTaskStatus);
        }

        // GET: Admin/ProjectTaskStatus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTaskStatus = await _context.ProjectTaskStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectTaskStatus == null)
            {
                return NotFound();
            }

            return View(projectTaskStatus);
        }

        // POST: Admin/ProjectTaskStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var projectTaskStatus = await _context.ProjectTaskStatus.FindAsync(id);
            _context.ProjectTaskStatus.Remove(projectTaskStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectTaskStatusExists(Guid id)
        {
            return _context.ProjectTaskStatus.Any(e => e.Id == id);
        }
    }
}
