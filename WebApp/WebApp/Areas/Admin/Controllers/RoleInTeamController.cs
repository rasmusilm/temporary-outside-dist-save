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
    public class RoleInTeamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoleInTeamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/RoleInTeam
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RoleInTeams.Include(r => r.Team).Include(r => r.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/RoleInTeam/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleInTeam = await _context.RoleInTeams
                .Include(r => r.Team)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roleInTeam == null)
            {
                return NotFound();
            }

            return View(roleInTeam);
        }

        // GET: Admin/RoleInTeam/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Admin/RoleInTeam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TeamId,UserId")] RoleInTeam roleInTeam)
        {
            if (ModelState.IsValid)
            {
                roleInTeam.Id = Guid.NewGuid();
                _context.Add(roleInTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", roleInTeam.TeamId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", roleInTeam.UserId);
            return View(roleInTeam);
        }

        // GET: Admin/RoleInTeam/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleInTeam = await _context.RoleInTeams.FindAsync(id);
            if (roleInTeam == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", roleInTeam.TeamId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", roleInTeam.UserId);
            return View(roleInTeam);
        }

        // POST: Admin/RoleInTeam/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,TeamId,UserId")] RoleInTeam roleInTeam)
        {
            if (id != roleInTeam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roleInTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleInTeamExists(roleInTeam.Id))
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
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", roleInTeam.TeamId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", roleInTeam.UserId);
            return View(roleInTeam);
        }

        // GET: Admin/RoleInTeam/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleInTeam = await _context.RoleInTeams
                .Include(r => r.Team)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roleInTeam == null)
            {
                return NotFound();
            }

            return View(roleInTeam);
        }

        // POST: Admin/RoleInTeam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var roleInTeam = await _context.RoleInTeams.FindAsync(id);
            _context.RoleInTeams.Remove(roleInTeam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleInTeamExists(Guid id)
        {
            return _context.RoleInTeams.Any(e => e.Id == id);
        }
    }
}
