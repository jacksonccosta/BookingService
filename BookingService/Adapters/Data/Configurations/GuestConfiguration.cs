using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Name).IsRequired().HasMaxLength(100);
        builder.Property(g => g.Surname).IsRequired().HasMaxLength(100);
        builder.Property(g => g.Email).IsRequired().HasMaxLength(250);

        builder.OwnsOne(g => g.DocumentId).Property(d => d.IdNumber).HasMaxLength(50);
        builder.OwnsOne(g => g.DocumentId).Property(d => d.DocumentType);

        builder.ToTable("Guests");
    }
}
