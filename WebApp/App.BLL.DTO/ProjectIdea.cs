using System.ComponentModel.DataAnnotations;
using App.Base;
using App.Domain.Identity;
using User = App.BLL.DTO.Identity.User;

namespace App.BLL.DTO;

public class ProjectIdea : DomainEntityId
{
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectIdea), Name = nameof(Title))]
    public string Title { get; set; } = "";
    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectIdea), Name = nameof(Explanation))]
    public string Explanation { get; set; } = "";
    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectIdea), Name = nameof(PostedAt))]
    public DateTime PostedAt { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectIdea), Name = nameof(Edited))]
    public bool Edited { get; set; } = false;
    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectIdea), Name = nameof(Deleted))]
    public bool Deleted { get; set; } = false;
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectIdea), Name = nameof(ComplexityId))]
    public Guid ComplexityId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectIdea), Name = nameof(Complexity))]
    public Complexity? Complexity { get; set; } = default!;
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectIdea), Name = nameof(DifficultyId))]
    public Guid DifficultyId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectIdea), Name = nameof(Difficulty))]
    public Difficulty? Difficulty { get; set; } = default!;

    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectIdea), Name = nameof(UserId))]
    public Guid UserId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectIdea), Name = nameof(User))]
    public User? User { get; set; } = default!;
    public double Rating { get; set; } = default!;
    public ICollection<IdeaTag>? IdeaTags { get; set; } = default!;
    public ICollection<Guid> TagIds { get; set; } = new List<Guid>();
    public ICollection<IdeaRating>? IdeaRatings { get; set; } = default!;
    public ICollection<IdeaInfeed>? IdeaInfeeds { get; set; } = default!;
}