using App.BLL.DTO;
using App.Contracts.BLL.Services;
using App.Contracts.DAL;
using Base.BLL;
using Base.Contracts.Base;

namespace App.BLL.Services;

public class IdeaRatingService : BaseEntityService<IdeaRating, App.DAL.DTO.IdeaRating, IIdeaRatingRepository>, IIdeaRatingService
{
    public IdeaRatingService(IIdeaRatingRepository repository, IMapper<IdeaRating, DAL.DTO.IdeaRating> mapper) : base(repository, mapper)
    {
    }

    public Task<IEnumerable<DAL.DTO.IdeaRating>> GetAllOnPost(string postIdea)
    {
        throw new NotImplementedException();
    }
}