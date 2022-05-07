#nullable disable
using App.BLL.DTO;
using App.Contracts.BLL;
using Helpers.WebApp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.ApiControllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class IdeaFeedProfileController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public IdeaFeedProfileController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/IdeaFeedProfile
        [HttpGet]
        public async Task<IEnumerable<IdeaFeedProfile>> GetIdeaFeedProfiles()
        {
            return await _bll.IdeaFeedProfiles.GetAllByUser(User.GetUserId());
        }

        // GET: api/IdeaFeedProfile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdeaFeedProfile>> GetIdeaFeedProfile(Guid id)
        {
            var ideaFeedProfile = await _bll.IdeaFeedProfiles.FirstOrDefaultAsync(id);

            if (ideaFeedProfile == null || ideaFeedProfile.UserId != User.GetUserId())
            {
                return NotFound();
            }

            return ideaFeedProfile;
        }

        // PUT: api/IdeaFeedProfile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdeaFeedProfile(Guid id, IdeaFeedProfile ideaFeedProfile)
        {
            if (id != ideaFeedProfile.Id || ideaFeedProfile.UserId != User.GetUserId())
            {
                return BadRequest();
            }

            _bll.IdeaFeedProfiles.Update(ideaFeedProfile);

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdeaFeedProfileExists(id))
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

        // POST: api/IdeaFeedProfile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IdeaFeedProfile>> PostIdeaFeedProfile(IdeaFeedProfile ideaFeedProfile)
        {
            _bll.IdeaFeedProfiles.Add(ideaFeedProfile);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetIdeaFeedProfile", new { id = ideaFeedProfile.Id }, ideaFeedProfile);
        }

        // DELETE: api/IdeaFeedProfile/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdeaFeedProfile(Guid id)
        {
            var ideaFeedProfile = await _bll.IdeaFeedProfiles.FirstOrDefaultAsync(id);
            if (ideaFeedProfile == null || ideaFeedProfile.UserId != User.GetUserId())
            {
                return NotFound();
            }

            _bll.IdeaFeedProfiles.Remove(ideaFeedProfile);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private bool IdeaFeedProfileExists(Guid id)
        {
            return _bll.IdeaFeedProfiles.Exists(id);
        }
    }
}
