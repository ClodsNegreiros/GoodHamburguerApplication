using GoodHamburguerApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodHamburguerApplication.Infrastructure.Mappings
{
    public class ExtraMapping : IEntityTypeConfiguration<Extra>
    {
        public void Configure(EntityTypeBuilder<Extra> builder)
        {
            builder.HasKey(extra => extra.Id);

            builder.Property(extra => extra.Id);
            builder.Property(extra => extra.Name);
            builder.Property(extra => extra.Price);

            builder
             .HasMany(extra => extra.Orders)
             .WithMany(order => order.Extras)
             .UsingEntity(builder => builder.ToTable("OrderExtras"));
        }
    }
}
