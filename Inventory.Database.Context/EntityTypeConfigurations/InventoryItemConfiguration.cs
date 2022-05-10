using Inventory.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Database.Context.EntityTypeConfigurations;

public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
{
    public void Configure(EntityTypeBuilder<InventoryItem> builder)
    {
        builder.HasKey(ii => ii.Id);

        builder.Property(ii => ii.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(ii => ii.Count)
            .IsRequired();

        builder.Property(ii => ii.AdditionalInformation)
            .HasMaxLength(64);
    }
}