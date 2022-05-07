using App.Contracts.DAL;
using App.DAL.EF;
using App.Domain;
using Base.Contracts.Base;
using Base.DAL.EF;

namespace App.DAl.EF.Repositories;

public class IdeaRatingRepository: BaseEntityRepository<App.DAL.DTO.IdeaRating, IdeaRating, ApplicationDbContext>, IIdeaRatingRepository
{
    public IdeaRatingRepository(ApplicationDbContext dbContext, IMapper<App.DAL.DTO.IdeaRating, IdeaRating> mapper) : base(dbContext, mapper)
    {
    }
    
    public Task<IEnumerable<App.DAL.DTO.IdeaRating>> GetAllByUser(string username)
    {
        throw new NotImplementedException();
    }
    
    public Task<IEnumerable<App.DAL.DTO.IdeaRating>> GetAllOnPost(string postIdea)
    {
        throw new NotImplementedException();
    }
}