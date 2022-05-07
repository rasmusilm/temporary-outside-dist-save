using System.ComponentModel.DataAnnotations;
using App.Base;

namespace App.BLL.DTO;

public class FeedTag : DomainEntityId
{
    [Display( ResourceType = typeof(App.Resourses.App.Domain.FeedTag), Name = nameof(App.Resourses.App.Domain.FeedTag.Tag))]
    public Tag? Tag { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.FeedTag), Name = nameof(App.Resourses.App.Domain.FeedTag.TagId))]
    public Guid TagId { get; set; }

    [Display( ResourceType = typeof(App.Resourses.App.Domain.FeedTag), Name = nameof(App.Resourses.App.Domain.FeedTag.IdeaFeedProfile))]
    public IdeaFeedProfile? IdeaFeedProfile { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.FeedTag), Name = nameof(App.Resourses.App.Domain.FeedTag.IdeaFeedProfileId))]
    public Guid IdeaFeedProfileId { get; set; }
}