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
    public class CommentRatingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentRatingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CommentRating
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CommentRatings.Include(c => c.Comment).Include(c => c.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/CommentRating/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentRating = await _context.CommentRatings
                .Include(c => c.Comment)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentRating == null)
            {
                return NotFound();
            }

            return View(commentRating);
        }

        // GET: Admin/CommentRating/Create
        public IActionResult Create()
        {
            ViewData["CommentId"] = new SelectList(_context.Comments, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Admin/CommentRating/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vote,UserId,CommentId")] CommentRating commentRating)
        {
            if (ModelState.IsValid)
            {
                commentRating.Id = Guid.NewGuid();
                _context.Add(commentRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommentId"] = new SelectList(_context.Comments, "Id", "Id", commentRating.CommentId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", commentRating.UserId);
            return View(commentRating);
        }

        // GET: Admin/CommentRating/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentRating = await _context.CommentRatings.FindAsync(id);
            if (commentRating == null)
            {
                return NotFound();
            }
            ViewData["CommentId"] = new SelectList(_context.Comments, "Id", "Id", commentRating.CommentId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", commentRating.UserId);
            return View(commentRating);
        }

        // POST: Admin/CommentRating/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Vote,UserId,CommentId")] CommentRating commentRating)
        {
            if (id != commentRating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentRatingExists(commentRating.Id))
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
            ViewData["CommentId"] = new SelectList(_context.Comments, "Id", "Id", commentRating.CommentId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", commentRating.UserId);
            return View(commentRating);
        }

        // GET: Admin/CommentRating/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentRating = await _context.CommentRatings
                .Include(c => c.Comment)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentRating == null)
            {
                return NotFound();
            }

            return View(commentRating);
        }

        // POST: Admin/CommentRating/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var commentRating = await _context.CommentRatings.FindAsync(id);
            _context.CommentRatings.Remove(commentRating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentRatingExists(Guid id)
        {
            return _context.CommentRatings.Any(e => e.Id == id);
        }
    }
}
