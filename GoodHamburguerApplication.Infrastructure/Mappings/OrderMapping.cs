using GoodHamburguerApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodHamburguerApplication.Infrastructure.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);

            builder.Property(order => order.TotalPrice);
            builder.Property(order => order.Discount);
            builder.Property(order => order.CreatedAt);
            builder.Property(order => order.SandwichId);
            builder.Property(order => order.ExtraId);

            builder
              .HasOne(order => order.Sandwich)
              .WithMany(sandwich => sandwich.Orders)
              .HasForeignKey(order => order.SandwichId);

            builder
              .HasOne(order => order.Extra)
              .WithMany(extra => extra.Orders)
              .HasForeignKey(order => order.SandwichId);
        }
    }
}
