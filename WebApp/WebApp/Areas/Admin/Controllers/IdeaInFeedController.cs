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
    public class IdeaInFeedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IdeaInFeedController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/IdeaInFeed
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IdeaInfeeds.Include(i => i.IdeaFeedProfile).Include(i => i.ProjectIdea);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/IdeaInFeed/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaInfeed = await _context.IdeaInfeeds
                .Include(i => i.IdeaFeedProfile)
                .Include(i => i.ProjectIdea)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ideaInfeed == null)
            {
                return NotFound();
            }

            return View(ideaInfeed);
        }

        // GET: Admin/IdeaInFeed/Create
        public IActionResult Create()
        {
            ViewData["IdeaFeedProfileid"] = new SelectList(_context.IdeaFeedProfiles, "Id", "Name");
            ViewData["ProjectIdeaId"] = new SelectList(_context.ProjectIdeas, "Id", "Explanation");
            return View();
        }

        // POST: Admin/IdeaInFeed/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdeaFeedProfileid,ProjectIdeaId")] IdeaInfeed ideaInfeed)
        {
            if (ModelState.IsValid)
            {
                ideaInfeed.Id = Guid.NewGuid();
                _context.Add(ideaInfeed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdeaFeedProfileid"] = new SelectList(_context.IdeaFeedProfiles, "Id", "Name", ideaInfeed.IdeaFeedProfileid);
            ViewData["ProjectIdeaId"] = new SelectList(_context.ProjectIdeas, "Id", "Explanation", ideaInfeed.ProjectIdeaId);
            return View(ideaInfeed);
        }

        // GET: Admin/IdeaInFeed/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaInfeed = await _context.IdeaInfeeds.FindAsync(id);
            if (ideaInfeed == null)
            {
                return NotFound();
            }
            ViewData["IdeaFeedProfileid"] = new SelectList(_context.IdeaFeedProfiles, "Id", "Name", ideaInfeed.IdeaFeedProfileid);
            ViewData["ProjectIdeaId"] = new SelectList(_context.ProjectIdeas, "Id", "Explanation", ideaInfeed.ProjectIdeaId);
            return View(ideaInfeed);
        }

        // POST: Admin/IdeaInFeed/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,IdeaFeedProfileid,ProjectIdeaId")] IdeaInfeed ideaInfeed)
        {
            if (id != ideaInfeed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ideaInfeed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdeaInfeedExists(ideaInfeed.Id))
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
            ViewData["IdeaFeedProfileid"] = new SelectList(_context.IdeaFeedProfiles, "Id", "Name", ideaInfeed.IdeaFeedProfileid);
            ViewData["ProjectIdeaId"] = new SelectList(_context.ProjectIdeas, "Id", "Explanation", ideaInfeed.ProjectIdeaId);
            return View(ideaInfeed);
        }

        // GET: Admin/IdeaInFeed/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaInfeed = await _context.IdeaInfeeds
                .Include(i => i.IdeaFeedProfile)
                .Include(i => i.ProjectIdea)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ideaInfeed == null)
            {
                return NotFound();
            }

            return View(ideaInfeed);
        }

        // POST: Admin/IdeaInFeed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ideaInfeed = await _context.IdeaInfeeds.FindAsync(id);
            _context.IdeaInfeeds.Remove(ideaInfeed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdeaInfeedExists(Guid id)
        {
            return _context.IdeaInfeeds.Any(e => e.Id == id);
        }
    }
}
