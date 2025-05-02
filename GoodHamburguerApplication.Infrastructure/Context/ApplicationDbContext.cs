using GoodHamburguerApplication.Domain.Entities;
using GoodHamburguerApplication.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguerApplication.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Sandwich> Sandwiches { get; set; }
        public DbSet<Extra> Extras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMapping());
            modelBuilder.ApplyConfiguration(new SandwichMapping());
            modelBuilder.ApplyConfiguration(new ExtraMapping());
        }
    }
}
