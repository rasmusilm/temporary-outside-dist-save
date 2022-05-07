@echo off
set timestamp=%DATE:/=-%_%TIME::=-%
set timestamp=%timestamp: =%
dotnet ef migrations add --project DAL.App --startup-project WebApp %timestamp%
dotnet ef database update --project DAL.App --startup-project WebApp
cd ./WebApp/
dotnet-aspnet-codegenerator controller -name CommentController -actions -m Domain.App.Comment -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name CommentRatingController -actions -m Domain.App.CommentRating -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name ComplexityController -actions -m Domain.App.Complexity -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name DifficultyController -actions -m Domain.App.Difficulty -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name FeedTagsController -actions -m Domain.App.FeedTag -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name IdeaFeedProfileController -actions -m Domain.App.IdeaFeedProfile -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name IdeaInFeedController -actions -m Domain.App.IdeaInfeed -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name IdeaRatingController -actions -m Domain.App.IdeaRating -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name IdeaTagController -actions -m Domain.App.IdeaTag -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name ProjectController -actions -m Domain.App.Project -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name ProjectIdeaController -actions -m Domain.App.ProjectIdea -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name ProjectTaskController -actions -m Domain.App.ProjectTask -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name ProjectTaskStatusController -actions -m Domain.App.ProjectTaskStatus -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name TagController -actions -m Domain.App.Tag -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name TeamController -actions -m Domain.App.Team -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name TeamInProjectController -actions -m Domain.App.TeamInProject -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name UserInProjectController -actions -m Domain.App.UserInProject -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet-aspnet-codegenerator controller -name UserInTeamController -actions -m Domain.App.UserInTeam -dc DAL.App.ApplicationDbContext -outDir Areas\Admin\Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
cd ..