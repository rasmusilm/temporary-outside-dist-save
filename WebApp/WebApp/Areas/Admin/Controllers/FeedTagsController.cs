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
    public class FeedTagsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedTagsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/FeedTags
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FeedTags.Include(f => f.IdeaFeedProfile).Include(f => f.Tag);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/FeedTags/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedTag = await _context.FeedTags
                .Include(f => f.IdeaFeedProfile)
                .Include(f => f.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedTag == null)
            {
                return NotFound();
            }

            return View(feedTag);
        }

        // GET: Admin/FeedTags/Create
        public IActionResult Create()
        {
            ViewData["IdeaFeedProfileId"] = new SelectList(_context.IdeaFeedProfiles, "Id", "Name");
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Tagname");
            return View();
        }

        // POST: Admin/FeedTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TagId,IdeaFeedProfileId")] FeedTag feedTag)
        {
            if (ModelState.IsValid)
            {
                feedTag.Id = Guid.NewGuid();
                _context.Add(feedTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdeaFeedProfileId"] = new SelectList(_context.IdeaFeedProfiles, "Id", "Name", feedTag.IdeaFeedProfileId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Tagname", feedTag.TagId);
            return View(feedTag);
        }

        // GET: Admin/FeedTags/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedTag = await _context.FeedTags.FindAsync(id);
            if (feedTag == null)
            {
                return NotFound();
            }
            ViewData["IdeaFeedProfileId"] = new SelectList(_context.IdeaFeedProfiles, "Id", "Name", feedTag.IdeaFeedProfileId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Tagname", feedTag.TagId);
            return View(feedTag);
        }

        // POST: Admin/FeedTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TagId,IdeaFeedProfileId")] FeedTag feedTag)
        {
            if (id != feedTag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedTagExists(feedTag.Id))
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
            ViewData["IdeaFeedProfileId"] = new SelectList(_context.IdeaFeedProfiles, "Id", "Name", feedTag.IdeaFeedProfileId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Tagname", feedTag.TagId);
            return View(feedTag);
        }

        // GET: Admin/FeedTags/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedTag = await _context.FeedTags
                .Include(f => f.IdeaFeedProfile)
                .Include(f => f.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedTag == null)
            {
                return NotFound();
            }

            return View(feedTag);
        }

        // POST: Admin/FeedTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var feedTag = await _context.FeedTags.FindAsync(id);
            _context.FeedTags.Remove(feedTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedTagExists(Guid id)
        {
            return _context.FeedTags.Any(e => e.Id == id);
        }
    }
}
