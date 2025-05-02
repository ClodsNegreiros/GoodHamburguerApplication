using GoodHamburguerApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodHamburguerApplication.Infrastructure.Mappings
{
    public class SandwichMapping : IEntityTypeConfiguration<Sandwich>
    {
        public void Configure(EntityTypeBuilder<Sandwich> builder)
        {
            builder.HasKey(sandwich => sandwich.Id);

            builder.Property(sandwich => sandwich.Id);
            builder.Property(sandwich => sandwich.Name);
            builder.Property(sandwich => sandwich.Price);

            builder
             .HasMany(sandwich => sandwich.Orders)
             .WithOne(order => order.Sandwich)
             .HasForeignKey(order => order.SandwichId);
        }
    }
}
