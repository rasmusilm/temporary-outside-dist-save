#nullable disable
using App.BLL.DTO;
using App.Contracts.BLL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.ApiControllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class IdeaRatingController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public IdeaRatingController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/IdeaRating
        [HttpGet]
        public async Task<IEnumerable<IdeaRating>> GetIdeaRatings()
        {
            return await _bll.IdeaRatings.GetAllAsync();
        }

        // GET: api/IdeaRating/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdeaRating>> GetIdeaRating(Guid id)
        {
            var ideaRating = await _bll.IdeaRatings.FirstOrDefaultAsync(id);

            if (ideaRating == null)
            {
                return NotFound();
            }

            return ideaRating;
        }

        // PUT: api/IdeaRating/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdeaRating(Guid id, IdeaRating ideaRating)
        {
            if (id != ideaRating.Id)
            {
                return BadRequest();
            }

            _bll.IdeaRatings.Update(ideaRating);

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdeaRatingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/IdeaRating
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IdeaRating>> PostIdeaRating(IdeaRating ideaRating)
        {
            _bll.IdeaRatings.Add(ideaRating);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetIdeaRating", new { id = ideaRating.Id }, ideaRating);
        }

        // DELETE: api/IdeaRating/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdeaRating(Guid id)
        {
            var ideaRating = await _bll.IdeaRatings.FirstOrDefaultAsync(id);
            if (ideaRating == null)
            {
                return NotFound();
            }

            _bll.IdeaRatings.Remove(ideaRating);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private bool IdeaRatingExists(Guid id)
        {
            return _bll.IdeaRatings.Exists(id);
        }
    }
}
