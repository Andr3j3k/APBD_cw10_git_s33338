using APBD_cw10_git_s33338.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_cw10_git_s33338.Configurations;

public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> builder)
    {
        builder.ToTable("ComponentTypes");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Abbreviation)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasData(
            new ComponentType
            {
                Id = 1,
                Abbreviation = "CPU",
                Name = "Processor"
            },
            new ComponentType
            {
                Id = 2,
                Abbreviation = "GPU",
                Name = "Graphics Card"
            },
            new ComponentType
            {
                Id = 3,
                Abbreviation = "RAM",
                Name = "Memory"
            }
        );
    }
}