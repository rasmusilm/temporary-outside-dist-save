using App.Contracts.BLL.Services;
using Base.Contracts.BLL;

namespace App.Contracts.BLL;

public interface IAppBLL : IBLL
{
    IProjectIdeaService ProjectIdeas { get; }
    IIdeaRatingService IdeaRatings { get; }
    IIdeaFeedProfileService IdeaFeedProfiles { get; }
    ITagService Tags { get; }
}