using System.ComponentModel.DataAnnotations;
using App.Base;
using App.Domain.Identity;
using App.Resourses;
using User = App.DAL.DTO.Identity.User;

namespace App.DAL.DTO;

public class Comment : DomainEntityId
{
    [Display(ResourceType = typeof(App.Resourses.App.Domain.Comment),
        Name = nameof(App.Resourses.App.Domain.Comment.Text))]
    public string? Text { get; set; }

    [Display(ResourceType = typeof(App.Resourses.App.Domain.Comment),
        Name = nameof(App.Resourses.App.Domain.Comment.PrjectIdeaId))]
    public Guid ProjectIdeaId { get; set; }
    [Display(ResourceType = typeof(App.Resourses.App.Domain.Comment),
        Name = nameof(App.Resourses.App.Domain.Comment.ProjectIdea))]
    public ProjectIdea? ProjectIdea { get; set; }

    [Display(ResourceType = typeof(App.Resourses.App.Domain.Comment),
        Name = nameof(App.Resourses.App.Domain.Comment.UserId))]
    public Guid UserId { get; set; }
    [Display(ResourceType = typeof(App.Resourses.App.Domain.Comment),
        Name = nameof(App.Resourses.App.Domain.Comment.User))]
    public User? User { get; set; }

    public ICollection<CommentRating>? CommentRatings { get; set; }
}