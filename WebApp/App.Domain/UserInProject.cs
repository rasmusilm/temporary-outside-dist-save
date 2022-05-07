using System.ComponentModel.DataAnnotations;
using App.Base;
using App.Domain.Enums;
using App.Domain.Identity;

namespace App.Domain;

public class UserInProject : DomainEntityId
{

    [Display( ResourceType = typeof(App.Resourses.App.Domain.UserInProject), Name = nameof(App.Resourses.App.Domain.UserInProject.RoleInProject))]
    public ERoleInProject RoleInProject { get; set; } = ERoleInProject.Owner;

    [Display( ResourceType = typeof(App.Resourses.App.Domain.UserInProject), Name = nameof(App.Resourses.App.Domain.UserInProject.UserId))]
    public Guid UserId { get; set; }
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.UserInProject), Name = nameof(App.Resourses.App.Domain.UserInProject.User))]
    public User? User { get; set; }

    [Display( ResourceType = typeof(App.Resourses.App.Domain.UserInProject), Name = nameof(App.Resourses.App.Domain.UserInProject.ProjectId))]
    public Guid ProjectId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.UserInProject), Name = nameof(App.Resourses.App.Domain.UserInProject.Project))]
    public Project? Project { get; set; }
}