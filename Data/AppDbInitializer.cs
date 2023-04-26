using Microsoft.AspNetCore.Identity;
using Samit_For_Entertainment.Data.enums;
using Samit_For_Entertainment.Data.Static;
using Samit_For_Entertainment.Models;

namespace Samit_For_Entertainment.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScop = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScop.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //CINAMA
                if (!context.CINAMAS.Any())
                {
                    context.CINAMAS.AddRange(new List<CINAMA>()
                    {
                        new CINAMA()
                        {
                            Name = "Cinema 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new CINAMA()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new CINAMA()
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new CINAMA()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new CINAMA()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                    });
                    context.SaveChanges();
                }

                //ACTOR
                if (!context.ACTORS.Any())
                {
                    context.ACTORS.AddRange(new List<ACTOR>()
                    {
                        new ACTOR()
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new ACTOR()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new ACTOR()
                        {
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new ACTOR()
                        {
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new ACTOR()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //PRODUCER
                if (!context.PRODUCERS.Any())
                {
                    context.PRODUCERS.AddRange(new List<PRODUCER>()
                    {
                        new PRODUCER()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new PRODUCER()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new PRODUCER()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new PRODUCER()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new PRODUCER()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();

                }
                //MOVIES
                if (!context.MOVIES.Any())
                {
                    context.MOVIES.AddRange(new List<MOVIE>()
                    {
                        new MOVIE()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CINAMAID = 3,
                            PRODUCERID = 3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new MOVIE()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CINAMAID = 1,
                            PRODUCERID = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new MOVIE()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CINAMAID = 4,
                            PRODUCERID = 4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new MOVIE()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CINAMAID = 1,
                            PRODUCERID = 2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new MOVIE()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CINAMAID = 1,
                            PRODUCERID = 3,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new MOVIE()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CINAMAID = 1,
                            PRODUCERID = 5,
                            MovieCategory = MovieCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }
                //ACROR_MOVIE
                if (!context.ACTORS_MOVIES.Any())
                {
                    context.ACTORS_MOVIES.AddRange(new List<ACTOR_MOVIE>()
                    {
                        new ACTOR_MOVIE()
                        {
                            ACTORID = 1,
                            MOVIEID = 1
                        },
                        new ACTOR_MOVIE()
                        {
                            ACTORID = 3,
                            MOVIEID = 1
                        },
                         new ACTOR_MOVIE()
                        {
                            ACTORID = 1,
                            MOVIEID = 2
                        },
                         new ACTOR_MOVIE()
                        {
                            ACTORID = 4,
                            MOVIEID = 2
                        },
                        new ACTOR_MOVIE()
                        {
                            ACTORID = 1,
                            MOVIEID = 3
                        },
                        new ACTOR_MOVIE()
                        {
                            ACTORID = 2,
                            MOVIEID = 3
                        },
                        new ACTOR_MOVIE()
                        {
                            ACTORID = 5,
                            MOVIEID = 3
                        },
                        new ACTOR_MOVIE()
                        {
                            ACTORID = 2,
                            MOVIEID = 4
                        },
                        new ACTOR_MOVIE()
                        {
                            ACTORID = 3,
                            MOVIEID = 4
                        },
                        new ACTOR_MOVIE()
                        {
                            ACTORID = 4,
                            MOVIEID = 4
                        },
                        new ACTOR_MOVIE()
                        {
                            ACTORID = 2,
                            MOVIEID = 5
                        },
                        new ACTOR_MOVIE()
                        {
                            ACTORID = 3,
                            MOVIEID = 5
                        },
                        new ACTOR_MOVIE()
                        {
                            ACTORID = 4,
                            MOVIEID = 5
                        },
                        new ACTOR_MOVIE()
                        {
                            ACTORID = 5,
                            MOVIEID = 5
                        },
                        new ACTOR_MOVIE()
                        {
                            ACTORID = 3,
                            MOVIEID = 6
                        },
                        new ACTOR_MOVIE()
                        {
                            ACTORID = 4,
                            MOVIEID = 6
                        },
                        new ACTOR_MOVIE()
                        {
                            ACTORID = 5,
                            MOVIEID = 6
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullNmae = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
                string appUserEmail = "user@etickets.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullNmae = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
