using App.Domain;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace App.DAL.EF;

public class ApplicationDbContext : IdentityDbContext<User, UserRole, Guid>
{
    public DbSet<RefreshToken> RefreshTokens { get; set; } = default!;
    public DbSet<TestItem> TestItems { get; set; } = default!;
    public DbSet<Difficulty> Difficulties { get; set; } = default!;
    public DbSet<Complexity> Complexities  { get; set; } = default!;
    public DbSet<ProjectIdea> ProjectIdeas  { get; set; } = default!;
    public DbSet<IdeaRating> IdeaRatings  { get; set; } = default!;
    public DbSet<IdeaTag> IdeaTags  { get; set; } = default!;
    public DbSet<Tag> Tags  { get; set; } = default!;
    public DbSet<Comment> Comments  { get; set; } = default!;
    public DbSet<CommentRating> CommentRatings  { get; set; } = default!;
    public DbSet<FeedTag> FeedTags  { get; set; } = default!;
    public DbSet<IdeaFeedProfile> IdeaFeedProfiles  { get; set; } = default!;
    public DbSet<IdeaInfeed> IdeaInfeeds  { get; set; } = default!;
    public DbSet<ProjectTask> ProjectTasks  { get; set; } = default!;
    public DbSet<ProjectTaskStatus> ProjectTaskStatus  { get; set; } = default!;
    public DbSet<Project> Projects  { get; set; } = default!;
    public DbSet<Team> Teams  { get; set; } = default!;
    public DbSet<UserInTeam> UserInTeams  { get; set; } = default!;
    public DbSet<RoleInTeam> RoleInTeams  { get; set; } = default!;
    public DbSet<UserInProject> UserInProjects { get; set; } = default!;
    public DbSet<TeamInProject> TeamInProjects { get; set; } = default!;
    

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        
        // Remove cascade delete
        foreach (var relationship in builder.Model
                     .GetEntityTypes()
                     .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        
    }

    public override int SaveChanges()
    {
        FixEntities(this);
        
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        FixEntities(this);
        
        return base.SaveChangesAsync(cancellationToken);
    }


    private void FixEntities(ApplicationDbContext context)
    {
        var dateProperties = context.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(DateTime))
            .Select(z => new
            {
                ParentName = z.DeclaringEntityType.Name,
                PropertyName = z.Name
            });

        var editedEntitiesInTheDbContextGraph = context.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
            .Select(x => x.Entity);
        

        foreach (var entity in editedEntitiesInTheDbContextGraph)
        {
            var entityFields = dateProperties.Where(d => d.ParentName == entity.GetType().FullName);

            foreach (var property in entityFields)
            {
                var prop = entity.GetType().GetProperty(property.PropertyName);

                if (prop == null)
                    continue;

                var originalValue = prop.GetValue(entity) as DateTime?;
                if (originalValue == null)
                    continue;

                prop.SetValue(entity, DateTime.SpecifyKind(originalValue.Value, DateTimeKind.Utc));
            }
        }
    }

}