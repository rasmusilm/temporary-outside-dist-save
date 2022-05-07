using App.BLL.DTO;
using App.Contracts.BLL.Services;
using App.Contracts.DAL;
using Base.BLL;
using Base.Contracts.Base;

namespace App.BLL.Services;

public class IdeaFeedService : BaseEntityService<IdeaFeedProfile, DAL.DTO.IdeaFeedProfile, IIdeaFeedProfileRepository>, IIdeaFeedProfileService
{
    public IdeaFeedService(IIdeaFeedProfileRepository repository, IMapper<IdeaFeedProfile, DAL.DTO.IdeaFeedProfile> mapper) : base(repository, mapper)
    {
    }

    public async Task<IEnumerable<IdeaFeedProfile>> GetAllByUser(Guid id)
    {
        return (await Repository.GetAllByUser(id)).Select(x => Mapper.Map(x)!);
    }
}