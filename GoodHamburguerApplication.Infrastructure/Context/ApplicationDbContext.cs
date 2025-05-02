using GoodHamburguerApplication.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguerApplication.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMapping());
            modelBuilder.ApplyConfiguration(new SandwichMapping());
            modelBuilder.ApplyConfiguration(new ExtraMapping());
        }
    }
}
