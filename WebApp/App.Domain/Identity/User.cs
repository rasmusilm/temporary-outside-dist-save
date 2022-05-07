using Microsoft.AspNetCore.Identity;

namespace App.Domain.Identity;

public class User : IdentityUser<Guid>
{
    public ICollection<IdeaRating>? IdeaRatings { get; set; } = default!;
    public ICollection<ProjectIdea>? ProjectIdeas { get; set; } = default!;
    public ICollection<IdeaFeedProfile>? IdeaFeedProfiles { get; set; } = default!;
    public ICollection<Comment>? Comments { get; set; } = default!;
    public ICollection<CommentRating>? CommentRatings { get; set; } = default!;
    public ICollection<Project>? Projects { get; set; } = default!;
    public ICollection<UserInTeam>? UserInTeams { get; set; } = default!;
    public ICollection<UserInProject>? UserInProjects { get; set; } = default!;
    public ICollection<RefreshToken>? RefreshTokens { get; set; } = new List<RefreshToken>();
    
    public string? Name { get; set; } = "default";
}