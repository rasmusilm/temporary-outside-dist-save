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
    public class IdeaFeedProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IdeaFeedProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/IdeaFeedProfile
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IdeaFeedProfiles.Include(i => i.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/IdeaFeedProfile/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaFeedProfile = await _context.IdeaFeedProfiles
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ideaFeedProfile == null)
            {
                return NotFound();
            }

            return View(ideaFeedProfile);
        }

        // GET: Admin/IdeaFeedProfile/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Admin/IdeaFeedProfile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UserId")] IdeaFeedProfile ideaFeedProfile)
        {
            if (ModelState.IsValid)
            {
                ideaFeedProfile.Id = Guid.NewGuid();
                _context.Add(ideaFeedProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ideaFeedProfile.UserId);
            return View(ideaFeedProfile);
        }

        // GET: Admin/IdeaFeedProfile/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaFeedProfile = await _context.IdeaFeedProfiles.FindAsync(id);
            if (ideaFeedProfile == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ideaFeedProfile.UserId);
            return View(ideaFeedProfile);
        }

        // POST: Admin/IdeaFeedProfile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,UserId")] IdeaFeedProfile ideaFeedProfile)
        {
            if (id != ideaFeedProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ideaFeedProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdeaFeedProfileExists(ideaFeedProfile.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ideaFeedProfile.UserId);
            return View(ideaFeedProfile);
        }

        // GET: Admin/IdeaFeedProfile/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaFeedProfile = await _context.IdeaFeedProfiles
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ideaFeedProfile == null)
            {
                return NotFound();
            }

            return View(ideaFeedProfile);
        }

        // POST: Admin/IdeaFeedProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ideaFeedProfile = await _context.IdeaFeedProfiles.FindAsync(id);
            _context.IdeaFeedProfiles.Remove(ideaFeedProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdeaFeedProfileExists(Guid id)
        {
            return _context.IdeaFeedProfiles.Any(e => e.Id == id);
        }
    }
}
