using System.ComponentModel.DataAnnotations;
using App.Base;
using App.Domain.Identity;

namespace App.BLL.DTO;

public class IdeaRating : DomainEntityId
{
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Idearating), Name = nameof(App.Resourses.App.Domain.Idearating.Rating))]
    public int Rating { get; set; }
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Idearating), Name = nameof(App.Resourses.App.Domain.Idearating.UserId))]
    public Guid UserId { get; set; }
    // [Display( ResourceType = typeof(App.Resourses.App.Domain.Idearating), Name = nameof(App.Resourses.App.Domain.Idearating.User))]
    // public User? User { get; set; }
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Idearating), Name = nameof(App.Resourses.App.Domain.Idearating.ProjectIdeaId))]
    public Guid ProjectIdeaId { get; set; }
    // [Display( ResourceType = typeof(App.Resourses.App.Domain.Idearating), Name = nameof(App.Resourses.App.Domain.Idearating.ProjectIdea))]
    // public ProjectIdea? ProjectIdea { get; set; }
}