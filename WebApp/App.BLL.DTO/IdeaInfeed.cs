using System.ComponentModel.DataAnnotations;
using App.Base;

namespace App.BLL.DTO;

public class IdeaInfeed : DomainEntityId
{
    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaInFeed), Name = nameof(App.Resourses.App.Domain.IdeaInFeed.IdeaFeedprofile))]
    public IdeaFeedProfile? IdeaFeedProfile { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaInFeed), Name = nameof(App.Resourses.App.Domain.IdeaInFeed.IdeaFeedProfileId))]
    public Guid IdeaFeedProfileid { get; set; }

    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaInFeed), Name = nameof(App.Resourses.App.Domain.IdeaInFeed.ProjectIdeaId))]
    public Guid ProjectIdeaId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaInFeed), Name = nameof(App.Resourses.App.Domain.IdeaInFeed.ProjectIdea))]
    public ProjectIdea? ProjectIdea { get; set; }
}