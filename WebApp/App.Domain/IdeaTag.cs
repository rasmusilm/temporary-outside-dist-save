using System.ComponentModel.DataAnnotations;
using App.Base;


namespace App.Domain;

public class IdeaTag : DomainEntityId
{
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaTag), Name = nameof(App.Resourses.App.Domain.IdeaTag.ProjectIdeaId))]
    public Guid ProjectIdeaId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaTag), Name = nameof(App.Resourses.App.Domain.IdeaTag.ProjectIdea))]
    public ProjectIdea? ProjectIdea { get; set; } = default!;
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaTag), Name = nameof(App.Resourses.App.Domain.IdeaTag.TagId))]
    public Guid TagId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaTag), Name = nameof(App.Resourses.App.Domain.IdeaTag.Tag))]
    public Tag? Tag { get; set; } = default!;
}