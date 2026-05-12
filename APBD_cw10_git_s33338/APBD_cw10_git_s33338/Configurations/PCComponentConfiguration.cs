using APBD_cw10_git_s33338.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PCComponentConfiguration : IEntityTypeConfiguration<PCComponent>
{
    public void Configure(EntityTypeBuilder<PCComponent> builder)
    {
        builder.ToTable("PCComponents");

        builder.HasKey(e => new { e.PCId, e.ComponentCode });

        builder.Property(e => e.ComponentCode)
            .IsRequired()
            .HasColumnType("char(10)");

        builder.Property(e => e.Amount)
            .IsRequired();

        builder.HasOne(e => e.PC)
            .WithMany(e => e.PCComponents)
            .HasForeignKey(e => e.PCId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Component)
            .WithMany(e => e.PCComponents)
            .HasForeignKey(e => e.ComponentCode)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new PCComponent
            {
                PCId = 1,
                ComponentCode = "CPU0000001",
                Amount = 1
            },
            new PCComponent
            {
                PCId = 1,
                ComponentCode = "GPU0000001",
                Amount = 1
            },
            new PCComponent
            {
                PCId = 1,
                ComponentCode = "RAM0000001",
                Amount = 2
            },
            new PCComponent
            {
                PCId = 2,
                ComponentCode = "CPU0000001",
                Amount = 1
            },
            new PCComponent
            {
                PCId = 2,
                ComponentCode = "RAM0000001",
                Amount = 1
            },
            new PCComponent
            {
                PCId = 3,
                ComponentCode = "CPU0000001",
                Amount = 1
            },
            new PCComponent
            {
                PCId = 3,
                ComponentCode = "GPU0000001",
                Amount = 2
            },
            new PCComponent
            {
                PCId = 3,
                ComponentCode = "RAM0000001",
                Amount = 4
            }
        );
    }
}