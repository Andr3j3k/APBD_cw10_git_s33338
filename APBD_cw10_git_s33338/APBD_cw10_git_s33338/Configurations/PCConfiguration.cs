using APBD_cw10_git_s33338.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_cw10_git_s33338.Configurations;

public class PCConfiguration : IEntityTypeConfiguration<PC>
{
    public void Configure(EntityTypeBuilder<PC> builder)
    {
        builder.ToTable("PCs");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Weight)
            .IsRequired();

        builder.Property(e => e.Warranty)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(e => e.Stock)
            .IsRequired();

        builder.HasData(
            new PC
            {
                Id = 1,
                Name = "Gaming Beast X",
                Weight = 12.5,
                Warranty = 36,
                CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0),
                Stock = 5
            },
            new PC
            {
                Id = 2,
                Name = "Office Mini Pro",
                Weight = 4.2,
                Warranty = 24,
                CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0),
                Stock = 12
            },
            new PC
            {
                Id = 3,
                Name = "Creator Workstation",
                Weight = 15.8,
                Warranty = 48,
                CreatedAt = new DateTime(2026, 3, 20, 10, 15, 0),
                Stock = 3
            }
        );
    }
}