using App.DAL.DTO;
using Base.Contracts.DAL;

namespace App.Contracts.DAL;

public interface IIdeaRatingRepository : IEntityRepository<IdeaRating>
{
    Task<IEnumerable<App.DAL.DTO.IdeaRating>> GetAllByUser(string username);


    Task<IEnumerable<App.DAL.DTO.IdeaRating>> GetAllOnPost(string postIdea);
}

public interface IIdeaRatingRepositoryCustom<TEntity>
{
    Task<IEnumerable<App.DAL.DTO.IdeaRating>> GetAllOnPost(string postIdea);
}