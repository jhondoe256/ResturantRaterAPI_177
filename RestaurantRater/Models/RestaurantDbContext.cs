using Microsoft.EntityFrameworkCore;

namespace RestaurantRater.Models
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant()
                {
                    ID = 1,
                    Name = "Super Mario Pasta Cavern",
                    Address = "1Up Lane"
                },
                new Restaurant()
                {
                    ID = 2,
                    Name = "Bowsers Hot Chilli Shop!",
                    Address = "123 GRRRR Court"
                }
            );

            modelBuilder.Entity<Rating>().HasData(
                new Rating()
                {
                    ID = 1,
                    RestaurantID = 1,
                    FoodScore = Math.Round(7.5,2),
                    EnvironmentScore = Math.Round(8.8d,2),
                    CleanlinessScore = Math.Round(10d,2)
                },
                 new Rating()
                {
                    ID = 2,
                    RestaurantID = 1,
                    FoodScore = Math.Round(8.5,2),
                    EnvironmentScore = Math.Round(9.8d,2),
                    CleanlinessScore = Math.Round(9.9,2)
                },
                  new Rating()
                {
                    ID = 3,
                    RestaurantID = 2,
                    FoodScore = Math.Round(3.5,2),
                    EnvironmentScore = Math.Round(5.8d,2),
                    CleanlinessScore = Math.Round(10.0,2)
                },
                  new Rating()
                {
                    ID = 4,
                    RestaurantID = 2,
                    FoodScore = Math.Round(6.5,2),
                    EnvironmentScore = Math.Round(6.8d,2),
                    CleanlinessScore = Math.Round(7.0,2)
                }
            );
        }

    }
}