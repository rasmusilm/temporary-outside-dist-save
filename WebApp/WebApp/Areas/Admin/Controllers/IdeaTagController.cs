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
    public class IdeaTagController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IdeaTagController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/IdeaTag
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IdeaTags.Include(i => i.ProjectIdea).Include(i => i.Tag);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/IdeaTag/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaTag = await _context.IdeaTags
                .Include(i => i.ProjectIdea)
                .Include(i => i.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ideaTag == null)
            {
                return NotFound();
            }

            return View(ideaTag);
        }

        // GET: Admin/IdeaTag/Create
        public IActionResult Create()
        {
            ViewData["ProjectIdeaId"] = new SelectList(_context.ProjectIdeas, "Id", "Explanation");
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Tagname");
            return View();
        }

        // POST: Admin/IdeaTag/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectIdeaId,TagId")] IdeaTag ideaTag)
        {
            if (ModelState.IsValid)
            {
                ideaTag.Id = Guid.NewGuid();
                _context.Add(ideaTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectIdeaId"] = new SelectList(_context.ProjectIdeas, "Id", "Explanation", ideaTag.ProjectIdeaId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Tagname", ideaTag.TagId);
            return View(ideaTag);
        }

        // GET: Admin/IdeaTag/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaTag = await _context.IdeaTags.FindAsync(id);
            if (ideaTag == null)
            {
                return NotFound();
            }
            ViewData["ProjectIdeaId"] = new SelectList(_context.ProjectIdeas, "Id", "Explanation", ideaTag.ProjectIdeaId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Tagname", ideaTag.TagId);
            return View(ideaTag);
        }

        // POST: Admin/IdeaTag/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ProjectIdeaId,TagId")] IdeaTag ideaTag)
        {
            if (id != ideaTag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ideaTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdeaTagExists(ideaTag.Id))
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
            ViewData["ProjectIdeaId"] = new SelectList(_context.ProjectIdeas, "Id", "Explanation", ideaTag.ProjectIdeaId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Tagname", ideaTag.TagId);
            return View(ideaTag);
        }

        // GET: Admin/IdeaTag/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaTag = await _context.IdeaTags
                .Include(i => i.ProjectIdea)
                .Include(i => i.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ideaTag == null)
            {
                return NotFound();
            }

            return View(ideaTag);
        }

        // POST: Admin/IdeaTag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ideaTag = await _context.IdeaTags.FindAsync(id);
            _context.IdeaTags.Remove(ideaTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdeaTagExists(Guid id)
        {
            return _context.IdeaTags.Any(e => e.Id == id);
        }
    }
}
