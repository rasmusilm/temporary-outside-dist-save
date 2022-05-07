using System.ComponentModel.DataAnnotations;
using App.Base;
using App.Domain.Identity;

namespace App.Domain;

public class Project : DomainEntityId
{
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Project), Name = nameof(App.Resourses.App.Domain.Project.ProjectIdeaId))]
    public Guid? ProjectIdeaId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Project), Name = nameof(App.Resourses.App.Domain.Project.ProjectIdea))]
    public ProjectIdea? ProjectIdea { get; set; }

    [Display( ResourceType = typeof(App.Resourses.App.Domain.Project), Name = nameof(App.Resourses.App.Domain.Project.Name))]
    public string Name { get; set; } = default!;
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Project), Name = nameof(App.Resourses.App.Domain.Project.Description))]
    public string? Description { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Project), Name = nameof(App.Resourses.App.Domain.Project.Deadline))]
    public DateTime Deadline { get; set; }
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Project), Name = nameof(App.Resourses.App.Domain.Project.UserId))]
    public Guid UserId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Project), Name = nameof(App.Resourses.App.Domain.Project.User))]
    public User? User { get; set; }
    
    public ICollection<ProjectTask>? Tasks { get; set; } 
    public ICollection<TeamInProject>? TeamInProjects { get; set; }
    public ICollection<UserInProject>? UserInProjects { get; set; }
}