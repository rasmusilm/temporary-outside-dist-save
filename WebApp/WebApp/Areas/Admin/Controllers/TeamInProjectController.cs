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
    public class TeamInProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamInProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/TeamInProject
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TeamInProjects.Include(t => t.Project).Include(t => t.Team);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/TeamInProject/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamInProject = await _context.TeamInProjects
                .Include(t => t.Project)
                .Include(t => t.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamInProject == null)
            {
                return NotFound();
            }

            return View(teamInProject);
        }

        // GET: Admin/TeamInProject/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id");
            return View();
        }

        // POST: Admin/TeamInProject/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamId,ProjectId")] TeamInProject teamInProject)
        {
            if (ModelState.IsValid)
            {
                teamInProject.Id = Guid.NewGuid();
                _context.Add(teamInProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", teamInProject.ProjectId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", teamInProject.TeamId);
            return View(teamInProject);
        }

        // GET: Admin/TeamInProject/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamInProject = await _context.TeamInProjects.FindAsync(id);
            if (teamInProject == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", teamInProject.ProjectId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", teamInProject.TeamId);
            return View(teamInProject);
        }

        // POST: Admin/TeamInProject/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TeamId,ProjectId")] TeamInProject teamInProject)
        {
            if (id != teamInProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamInProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamInProjectExists(teamInProject.Id))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", teamInProject.ProjectId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", teamInProject.TeamId);
            return View(teamInProject);
        }

        // GET: Admin/TeamInProject/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamInProject = await _context.TeamInProjects
                .Include(t => t.Project)
                .Include(t => t.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamInProject == null)
            {
                return NotFound();
            }

            return View(teamInProject);
        }

        // POST: Admin/TeamInProject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var teamInProject = await _context.TeamInProjects.FindAsync(id);
            _context.TeamInProjects.Remove(teamInProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamInProjectExists(Guid id)
        {
            return _context.TeamInProjects.Any(e => e.Id == id);
        }
    }
}
