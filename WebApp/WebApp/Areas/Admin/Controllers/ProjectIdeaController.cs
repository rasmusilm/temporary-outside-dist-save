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
using Helpers.WebApp;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProjectIdeaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectIdeaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ProjectIdea
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjectIdeas.Where(t => t.UserId.Equals(User.GetUserId())).Include(p => p.Complexity).Include(p => p.Difficulty).Include(p => p.User);
            // https://localhost:7247/Admin/ProjectIdea/Edit/d1b2bc66-7b80-4216-812f-8dba2426de84
            // Where(t => t.UserId.Equals(User.GetUserId())).
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/ProjectIdea/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectIdea = await _context.ProjectIdeas
                .Include(p => p.Complexity)
                .Include(p => p.Difficulty)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectIdea == null)
            {
                return NotFound();
            }

            return View(projectIdea);
        }

        // GET: Admin/ProjectIdea/Create
        public IActionResult Create()
        {
            ViewData["ComplexityId"] = new SelectList(_context.Complexities, "Id", "Name");
            ViewData["DifficultyId"] = new SelectList(_context.Difficulties, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: Admin/ProjectIdea/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Explanation,PostedAt,Edited,Deleted,ComplexityId,DifficultyId,UserId")] ProjectIdea projectIdea)
        {
            if (ModelState.IsValid)
            {
                projectIdea.UserId = User.GetUserId();
                
                projectIdea.Id = Guid.NewGuid();
                
                _context.Add(projectIdea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComplexityId"] = new SelectList(_context.Complexities, "Id", "Id", projectIdea.ComplexityId);
            ViewData["DifficultyId"] = new SelectList(_context.Difficulties, "Id", "Id", projectIdea.DifficultyId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", projectIdea.UserId);
            return View(projectIdea);
        }

        // GET: Admin/ProjectIdea/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectIdea = await _context.ProjectIdeas.FindAsync(id);
            if (projectIdea == null || projectIdea.UserId != User.GetUserId())
            {
                return NotFound();
            }
            ViewData["ComplexityId"] = new SelectList(_context.Complexities, "Id", "Id", projectIdea.ComplexityId);
            ViewData["DifficultyId"] = new SelectList(_context.Difficulties, "Id", "Id", projectIdea.DifficultyId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", projectIdea.UserId);
            return View(projectIdea);
        }

        // POST: Admin/ProjectIdea/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Explanation,PostedAt,Edited,Deleted,ComplexityId,DifficultyId,UserId")] ProjectIdea projectIdea)
        {
            if (id != projectIdea.Id || projectIdea.UserId != User.GetUserId())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectIdea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectIdeaExists(projectIdea.Id))
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
            ViewData["ComplexityId"] = new SelectList(_context.Complexities, "Id", "Id", projectIdea.ComplexityId);
            ViewData["DifficultyId"] = new SelectList(_context.Difficulties, "Id", "Id", projectIdea.DifficultyId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", projectIdea.UserId);
            return View(projectIdea);
        }

        // GET: Admin/ProjectIdea/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectIdea = await _context.ProjectIdeas
                .Include(p => p.Complexity)
                .Include(p => p.Difficulty)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectIdea == null || projectIdea.UserId != User.GetUserId())
            {
                return NotFound();
            }

            return View(projectIdea);
        }

        // POST: Admin/ProjectIdea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var projectIdea = await _context.ProjectIdeas.FindAsync(id);
            _context.ProjectIdeas.Remove(projectIdea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectIdeaExists(Guid id)
        {
            return _context.ProjectIdeas.Any(e => e.Id == id);
        }
    }
}
