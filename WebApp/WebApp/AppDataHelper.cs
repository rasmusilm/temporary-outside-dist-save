using App.DAl.EF;
using App.DAL.EF;
using App.Domain;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebApp;

public class AppDataHelper
{
    public static void SetupAppData(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
    {
        using var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope();

        using var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

        if (context == null)
        {
            throw new ApplicationException("Problem in service");
        }

        if (configuration.GetValue<bool>("DataInitialization:DropDatabase"))
        {
            context.Database.EnsureDeleted();
        }
        
        if (configuration.GetValue<bool>("DataInitialization:MigrateDatabase"))
        {
            context.Database.Migrate();
        }
        // TODO - Check DB state

        if (configuration.GetValue<bool>("DataInitialization:SeedIdentity"))
        {
            using var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
            using var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<UserRole>>();

            if (userManager == null || roleManager == null)
            {
                throw new NullReferenceException("userManager or roleManager cannot be null!");
            }

            var roles = new string[]
            {
                "admin",
                "user"
            };

            foreach (var rolename in roles)
            {
                var role = roleManager.FindByNameAsync(rolename).Result;
                if (role == null)
                {
                    var identityResult = roleManager.CreateAsync(new UserRole()
                    {
                        Name = rolename,
                    }).Result;
                    if (!identityResult.Succeeded)
                    {
                        throw new ApplicationException("Role creation failed");
                    }
                }
            }

            var users = new (string username,string firstName,string lastName, string password, string roles)[]
            {
                ("admin@itcollege.ee","Admin","College", "Hea.Parool.1", "user,admin"),
                ("rasmus.ilmjarv@gmail.com","Rasmus","Ilmjärv", "Hea.Parool.1", "user,admin"),
                ("user@itcollege.ee","User","College", "Kala.maja1", "user"),
                ("newuser@itcollege.ee","User No Roles","College", "Kala.maja1", ""),
            };

            foreach (var userInfo in users)
            {
                var user = userManager.FindByEmailAsync(userInfo.username).Result;
                if (user == null)
                {
                    user = new User()
                    {
                        Email = userInfo.username,
                        UserName = userInfo.username,
                        EmailConfirmed = true,
                        Name = userInfo.firstName,
                    };
                    var identityResult = userManager.CreateAsync(user, userInfo.password).Result;
                    if (!identityResult.Succeeded)
                    {
                        throw new ApplicationException("Cannot create user!");
                    }
                }

                if (!string.IsNullOrWhiteSpace(userInfo.roles))
                {
                    var identityResultRole = userManager.AddToRolesAsync(user,
                        userInfo.roles.Split(",").Select(r => r.Trim())
                    ).Result;
                }
            }
        }
        
        if (configuration.GetValue<bool>("DataInitialization:SeedData"))
        {
            var test = new TestItem
            {
                Name =
                {
                    ["et-EE"] = "Estonian",
                    ["en-GB"] = "English(Traditional)"
                }
            };
            context.TestItems.Add(test);
            context.SaveChanges();

            var tag1 = new Tag
            {
                Tagname =
                {
                    ["et-EE"] = "Püüton",
                    ["en-GB"] = "Python"
                }
            };
            context.Tags.Add(tag1);
            context.SaveChanges();
            var tag2 = new Tag
            {
                Tagname =
                {
                    ["en-GB"] = "C#"
                }
            };
            context.Tags.Add(tag2);
            var tag3 = new Tag
            {
                Tagname =
                {
                    ["et-EE"] = "Veebirakendus",
                    ["en-GB"] = "WebApp"
                }
            };
            context.Tags.Add(tag3);
            var tag4 = new Tag
            {
                Tagname =
                {
                    ["et-EE"] = "Konsoolirakendus",
                    ["en-GB"] = "Console App"
                }
            };
            context.Tags.Add(tag4);
            var tag5 = new Tag
            {
                Tagname =
                {
                    ["et-EE"] = "Mobiilirakendus",
                    ["en-GB"] = "Mobile App"
                }
            };
            context.Tags.Add(tag5);
            var tag6 = new Tag
            {
                Tagname =
                {
                    ["et-EE"] = "Androidi rakendus",
                    ["en-GB"] = "Android App"
                }
            };
            context.Tags.Add(tag6);
            var tag7 = new Tag
            {
                Tagname =
                {
                    ["et-EE"] = "iOS rakendus",
                    ["en-GB"] = "iOS App"
                }
            };
            context.Tags.Add(tag7);
            var tag8 = new Tag
            {
                Tagname =
                {
                    ["et-EE"] = "Töölauarakendus",
                    ["en-GB"] = "Desktop App"
                }
            };
            context.Tags.Add(tag8);
            var tag9 = new Tag
            {
                Tagname =
                {
                    ["en-GB"] = "Static webpage",
                    ["et-EE"] = "Staatiline veebileht"
                }
            };
            context.Tags.Add(tag9);

            var difficulty = new Difficulty
            {
                Name =
                {
                    ["en-GB"] = "Easy",
                    ["et-EE"] = "Kerge"
                }
            };
            context.Difficulties.Add(difficulty);
            var difficulty1 = new Difficulty
            {
                Name =
                {
                    ["en-GB"] = "Intermediate",
                    ["et-EE"] = "Keskmine"
                }
            };
            context.Difficulties.Add(difficulty1);
            var difficulty2 = new Difficulty
            {
                Name =
                {
                    ["en-GB"] = "Hard",
                    ["et-EE"] = "Raske"
                }
            };
            context.Difficulties.Add(difficulty2);
            
            var complexity = new Complexity
            {
                Name =
                {
                    ["en-GB"] = "Simple",
                    ["et-EE"] = "Lihtne"
                }
            };
            context.Complexities.Add(complexity);
            var complexity1 = new Complexity
            {
                Name =
                {
                    ["en-GB"] = "Small app",
                    ["et-EE"] = "Väike rakendus"
                }
            };
            context.Complexities.Add(complexity1);
            var complexity2 = new Complexity
            {
                Name =
                {
                    ["en-GB"] = "Multy-part system",
                    ["et-EE"] = "Mitmeosaline süsteem"
                }
            };
            context.Complexities.Add(complexity2);
            
            context.SaveChanges();

            var user = context.Users.FirstOrDefault(u => u.Name == "Rasmus");

            context.ProjectIdeas.Add(
                new ProjectIdea
                {
                    Title = "Test Post",
                    Explanation = "Test Explanation",
                    PostedAt = DateTime.Now,
                    Complexity = complexity,
                    Difficulty = difficulty,
                    User = user,
                    UserId = user.Id
                }
                );
            context.SaveChanges();
        }
    }
}