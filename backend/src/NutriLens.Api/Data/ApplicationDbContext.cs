using Microsoft.EntityFrameworkCore;
using NutriLens.Api.Entities;
namespace NutriLens.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Nutrient> Nutrients => Set<Nutrient>();
        public DbSet<DailyRequirement> DailyRequirements => Set<DailyRequirement>();
        public DbSet<Food> Foods => Set<Food>();
        public DbSet<FoodNutrient> FoodNutrients => Set<FoodNutrient>();
        public DbSet<FoodLog> FoodLogs => Set<FoodLog>();
        public DbSet<FoodLogItem> FoodLogItems => Set<FoodLogItem>();
    }
}
