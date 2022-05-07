#nullable disable
using App.BLL.DTO;
using App.Contracts.BLL;
using Helpers.WebApp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.ApiControllers.Functional
{
    [Route("/api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProjectIdeaController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public ProjectIdeaController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/ProjectIdea
        [HttpGet]
        public async Task<IEnumerable<ProjectIdea>> GetProjectIdeas()
        {
            return await _bll.ProjectIdeas.GetAllAsync();
        }

        // GET: api/ProjectIdea/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectIdea>> GetProjectIdea(Guid id)
        {
            Console.WriteLine("happened");
            var projectIdea = await _bll.ProjectIdeas.FirstOrDefaultAsync(id);

            if (projectIdea == null)
            {
                return NotFound();
            }

            return projectIdea;
        }

        // PUT: api/ProjectIdea/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectIdea(Guid id, ProjectIdea projectIdea)
        {
            if (id != projectIdea.Id || projectIdea.UserId != User.GetUserId())
            {
                return BadRequest();
            }

            _bll.ProjectIdeas.Update(projectIdea);

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectIdeaExists(id))
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

        // POST: api/ProjectIdea
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectIdea>> PostProjectIdea(ProjectIdea projectIdea)
        {
            _bll.ProjectIdeas.Add(projectIdea);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetProjectIdea", new { id = projectIdea.Id }, projectIdea);
        }

        // DELETE: api/ProjectIdea/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectIdea(Guid id)
        {
            var projectIdea = await _bll.ProjectIdeas.FirstOrDefaultAsync(id);
            if (projectIdea == null || projectIdea.UserId != User.GetUserId())
            {
                return NotFound();
            }

            _bll.ProjectIdeas.Remove(projectIdea);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectIdeaExists(Guid id)
        {
            return _bll.ProjectIdeas.Exists(id);
        }
    }
}
