using App.Contracts.DAL;
using App.DAL.DTO;
using App.Domain.Identity;
using Base.Contracts.Base;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using IdeaRating = App.Domain.IdeaRating;
using User = App.DAL.DTO.Identity.User;

namespace App.DAL.EF.Repositories;

public class ProjectIdeaRepository : BaseEntityRepository<ProjectIdea, App.Domain.ProjectIdea, ApplicationDbContext>, IProjectIdeaRepository
{
    private readonly ApplicationDbContext _context;
    public ProjectIdeaRepository(ApplicationDbContext dbContext, IMapper<ProjectIdea, App.Domain.ProjectIdea> mapper) : base(dbContext, mapper)
    {
        _context = dbContext;
    }

    public override async Task<IEnumerable<ProjectIdea>> GetAllAsync(bool noTracking = true)
    {
        return (
                await CreateQuery(noTracking)
                    .Include(p => p.User)
                    .Include(p => p.IdeaRatings)
                    .Include(p => p.IdeaTags)
                    .ToListAsync()
            )
            .Select(x => Mapper.Map(x)!);
    }

    public async Task<IEnumerable<ProjectIdea>> GetAllByUser(Guid userId)
    {
        // var projectIdeas = _context.ProjectIdeas.Where(p => p.UserId.Equals(userId));
        // return projectIdeas.AsEnumerable();
        var query = CreateQuery(true);
        return (await query.Where(a => a.UserId == userId).ToListAsync()).Select(x => Mapper.Map(x)!);
    }

    public async Task<IEnumerable<ProjectIdea>> GetAllWithTag(Guid tagId)
    {
        var query = CreateQuery(true);
        return (await query.Where(a => a.IdeaTags!.Any(a => a.TagId == tagId)).ToListAsync()).Select(x => Mapper.Map(x)!);
    }
}