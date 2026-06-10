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
    }
}
