using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.Domain.Entities;

namespace Stock.Infrastructure.Persistence.Configurations;

public class InvoiceDetailConfig : IEntityTypeConfiguration<InvoiceDetail>
{
    public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
    {
        builder.HasOne(i => i.Item)
            .WithMany()
            .HasForeignKey(i => i.ItemId);

        builder.HasOne(i => i.Invoice)
            .WithMany(i => i.InvoiceDetails)
            .HasForeignKey(i => i.InvoiceId);
    }
}