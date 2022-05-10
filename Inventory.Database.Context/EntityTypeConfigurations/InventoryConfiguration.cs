using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Database.Context.EntityTypeConfigurations;

public class InventoryConfiguration : IEntityTypeConfiguration<Core.Models.Inventory>
{
    public void Configure(EntityTypeBuilder<Core.Models.Inventory> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(64);
    }
}