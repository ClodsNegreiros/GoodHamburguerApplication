using GoodHamburguerApplication.Domain.Entities;
using GoodHamburguerApplication.Infrastructure.Context;

namespace GoodHamburguerApplication.Infrastructure.Seed
{
    public static class InitialDataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Sandwiches.Any())
            {
                context.Sandwiches.AddRange(
                    new Sandwich { Name = "X Burger", Price = 5.00m },
                    new Sandwich { Name = "X Egg", Price = 4.50m },
                    new Sandwich { Name = "X Bacon", Price = 7.00m }
                );
            }

            if (!context.Extras.Any())
            {
                context.Extras.AddRange(
                    new Extra { Name = "Fries", Price = 2.00m },
                    new Extra { Name = "Soft drink", Price = 2.50m }
                );
            }

            context.SaveChanges();
        }
    }
}
