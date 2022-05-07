using System.ComponentModel.DataAnnotations;
using App.Base;

namespace App.BLL.DTO;

public class ProjectTask : DomainEntityId
{
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectTask), Name = nameof(App.Resourses.App.Domain.ProjectTask.Title))]
    public string? Title { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectTask), Name = nameof(App.Resourses.App.Domain.ProjectTask.Description))]
    public string? Description { get; set; }

    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectTask), Name = nameof(App.Resourses.App.Domain.ProjectTask.ProjectTaskStatusId))]
    public Guid ProjectTaskStatusId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectTask), Name = nameof(App.Resourses.App.Domain.ProjectTask.ProjectTaskStatus))]
    public ProjectTaskStatus? ProjectTaskStatus { get; set; }
}