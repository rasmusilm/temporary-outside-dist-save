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
    public class UserInTeamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserInTeamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/UserInTeam
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserInTeams.Include(u => u.Team).Include(u => u.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/UserInTeam/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInTeam = await _context.UserInTeams
                .Include(u => u.Team)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userInTeam == null)
            {
                return NotFound();
            }

            return View(userInTeam);
        }

        // GET: Admin/UserInTeam/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Admin/UserInTeam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,TeamId")] UserInTeam userInTeam)
        {
            if (ModelState.IsValid)
            {
                userInTeam.Id = Guid.NewGuid();
                _context.Add(userInTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", userInTeam.TeamId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userInTeam.UserId);
            return View(userInTeam);
        }

        // GET: Admin/UserInTeam/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInTeam = await _context.UserInTeams.FindAsync(id);
            if (userInTeam == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", userInTeam.TeamId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userInTeam.UserId);
            return View(userInTeam);
        }

        // POST: Admin/UserInTeam/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,UserId,TeamId")] UserInTeam userInTeam)
        {
            if (id != userInTeam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userInTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInTeamExists(userInTeam.Id))
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
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", userInTeam.TeamId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userInTeam.UserId);
            return View(userInTeam);
        }

        // GET: Admin/UserInTeam/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInTeam = await _context.UserInTeams
                .Include(u => u.Team)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userInTeam == null)
            {
                return NotFound();
            }

            return View(userInTeam);
        }

        // POST: Admin/UserInTeam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var userInTeam = await _context.UserInTeams.FindAsync(id);
            _context.UserInTeams.Remove(userInTeam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserInTeamExists(Guid id)
        {
            return _context.UserInTeams.Any(e => e.Id == id);
        }
    }
}
