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
    public class UserInProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserInProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/UserInProject
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserInProjects.Include(u => u.Project).Include(u => u.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/UserInProject/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInProject = await _context.UserInProjects
                .Include(u => u.Project)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userInProject == null)
            {
                return NotFound();
            }

            return View(userInProject);
        }

        // GET: Admin/UserInProject/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Admin/UserInProject/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoleInProject,UserId,ProjectId")] UserInProject userInProject)
        {
            if (ModelState.IsValid)
            {
                userInProject.Id = Guid.NewGuid();
                _context.Add(userInProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", userInProject.ProjectId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userInProject.UserId);
            return View(userInProject);
        }

        // GET: Admin/UserInProject/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInProject = await _context.UserInProjects.FindAsync(id);
            if (userInProject == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", userInProject.ProjectId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userInProject.UserId);
            return View(userInProject);
        }

        // POST: Admin/UserInProject/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,RoleInProject,UserId,ProjectId")] UserInProject userInProject)
        {
            if (id != userInProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userInProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInProjectExists(userInProject.Id))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", userInProject.ProjectId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userInProject.UserId);
            return View(userInProject);
        }

        // GET: Admin/UserInProject/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInProject = await _context.UserInProjects
                .Include(u => u.Project)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userInProject == null)
            {
                return NotFound();
            }

            return View(userInProject);
        }

        // POST: Admin/UserInProject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var userInProject = await _context.UserInProjects.FindAsync(id);
            _context.UserInProjects.Remove(userInProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserInProjectExists(Guid id)
        {
            return _context.UserInProjects.Any(e => e.Id == id);
        }
    }
}
