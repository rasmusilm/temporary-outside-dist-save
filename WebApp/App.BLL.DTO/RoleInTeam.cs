using System.ComponentModel.DataAnnotations;
using App.Base;
using App.Domain.Identity;

namespace App.BLL.DTO;

public class RoleInTeam : DomainEntityId
{
    [Display( ResourceType = typeof(App.Resourses.App.Domain.RoleInTeam), Name = nameof(App.Resourses.App.Domain.RoleInTeam.Name))]
    public string? Name { get; set; }
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.RoleInTeam), Name = nameof(App.Resourses.App.Domain.RoleInTeam.TeamId))]
    public Guid? TeamId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.RoleInTeam), Name = nameof(App.Resourses.App.Domain.RoleInTeam.Team))]
    public Team? Team { get; set; }
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.RoleInTeam), Name = nameof(App.Resourses.App.Domain.RoleInTeam.UserId))]
    public Guid? UserId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.RoleInTeam), Name = nameof(App.Resourses.App.Domain.RoleInTeam.User))]
    public User? User { get; set; }
}