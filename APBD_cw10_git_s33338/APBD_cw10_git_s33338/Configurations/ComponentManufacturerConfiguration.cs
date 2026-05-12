using APBD_cw10_git_s33338.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_cw10_git_s33338.Configurations;

public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> builder)
    {
        builder.ToTable("ComponentManufacturers");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Abbreviation)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(e => e.FullName)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(e => e.FoundationDate)
            .IsRequired()
            .HasColumnType("date");

        builder.HasData(
            new ComponentManufacturer
            {
                Id = 1,
                Abbreviation = "AMD",
                FullName = "Advanced Micro Devices",
                FoundationDate = new DateTime(1969, 5, 1)
            },
            new ComponentManufacturer
            {
                Id = 2,
                Abbreviation = "NV",
                FullName = "NVIDIA Corporation",
                FoundationDate = new DateTime(1993, 4, 5)
            },
            new ComponentManufacturer
            {
                Id = 3,
                Abbreviation = "COR",
                FullName = "Corsair Gaming Inc.",
                FoundationDate = new DateTime(1994, 1, 1)
            }
        );
    }
}