using APBD_cw10_git_s33338.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_cw10_git_s33338.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.ToTable("Components");

        builder.HasKey(e => e.Code);

        builder.Property(e => e.Code)
            .IsRequired()
            .HasColumnType("char(10)");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(e => e.Description)
            .HasColumnType("nvarchar(max)");

        builder.Property(e => e.ComponentManufacturerId)
            .HasColumnName("ComponentManufacturersId")
            .IsRequired();

        builder.Property(e => e.ComponentTypeId)
            .HasColumnName("ComponentTypesId")
            .IsRequired();

        builder.HasOne(e => e.ComponentManufacturer)
            .WithMany(e => e.Components)
            .HasForeignKey(e => e.ComponentManufacturerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ComponentType)
            .WithMany(e => e.Components)
            .HasForeignKey(e => e.ComponentTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new Component
            {
                Code = "CPU0000001",
                Name = "Ryzen 7 7800X3D",
                Description = "8-core gaming processor",
                ComponentManufacturerId = 1,
                ComponentTypeId = 1
            },
            new Component
            {
                Code = "GPU0000001",
                Name = "RTX 4080 Super",
                Description = "High-end gaming graphics card",
                ComponentManufacturerId = 2,
                ComponentTypeId = 2
            },
            new Component
            {
                Code = "RAM0000001",
                Name = "Corsair Vengeance DDR5 16GB",
                Description = "DDR5 RAM module 16GB",
                ComponentManufacturerId = 3,
                ComponentTypeId = 3
            }
        );
    }
}