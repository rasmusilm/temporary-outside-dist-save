using System.ComponentModel.DataAnnotations;
using App.Base;

namespace App.Domain;

public class ProjectTaskStatus : DomainEntityId
{
    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectTaskStatus), Name = nameof(App.Resourses.App.Domain.ProjectTaskStatus.Name))]
    public string Name { get; set; } = default!;
    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectTaskStatus), Name = nameof(App.Resourses.App.Domain.ProjectTaskStatus.Description))]
    public string? Description { get; set; }
    
    public ICollection<ProjectTask>? ProjectTasks { get; set; }
}