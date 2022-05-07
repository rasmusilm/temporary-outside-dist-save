@echo off
dotnet ef database drop --project DAL.App --startup-project WebApp
dotnet ef migrations add --project DAL.App --startup-project WebApp InitialCreation
dotnet ef database update --project DAL.App --startup-project WebApp
cd ./WebApp/
dotnet-aspnet-codegenerator controller -name CommentController -actions -m App.Domain.Comment -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name CommentRatingController -actions -m App.Domain.CommentRating -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name ComplexityController -actions -m App.Domain.Complexity -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name DifficultyController -actions -m App.Domain.Difficulty -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name FeedTagsController -actions -m App.Domain.FeedTag -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name IdeaFeedProfileController -actions -m App.Domain.IdeaFeedProfile -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name IdeaInFeedController -actions -m App.Domain.IdeaInfeed -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name IdeaRatingController -actions -m App.Domain.IdeaRating -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name IdeaTagController -actions -m App.Domain.IdeaTag -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name ProjectController -actions -m App.Domain.Project -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name ProjectIdeaController -actions -m App.Domain.ProjectIdea -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name ProjectTaskController -actions -m App.Domain.ProjectTask -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name ProjectTaskStatusController -actions -m App.Domain.ProjectTaskStatus -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name RoleInTeamController -actions -m App.Domain.RoleInTeam -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name TagController -actions -m App.Domain.Tag -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name TeamController -actions -m App.Domain.Team -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name TeamInProjectController -actions -m App.Domain.TeamInProject -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name UserInProjectController -actions -m App.Domain.UserInProject -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name UserInTeamController -actions -m App.Domain.UserInTeam -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
cd ..
