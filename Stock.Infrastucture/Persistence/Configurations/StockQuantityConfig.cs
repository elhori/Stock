using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.Domain.Entities;

namespace Stock.Infrastructure.Persistence.Configurations;

public class StockQuantityConfig : IEntityTypeConfiguration<StockQuantity>
{
    public void Configure(EntityTypeBuilder<StockQuantity> builder)
    {
        builder.HasOne(i => i.Item)
            .WithMany()
            .HasForeignKey(i => i.ItemId);

        builder.Property(i => i.UnitType)
            .HasConversion<string>();
    }
}