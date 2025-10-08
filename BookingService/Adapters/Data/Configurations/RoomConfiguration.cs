using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).HasMaxLength(100);
            builder.Property(r => r.Level);
            builder.Property(r => r.InMaintenance);

            builder.OwnsOne(r => r.Price, price =>
            {
                price.Property(p => p.Value).HasColumnType("decimal(18,2)");
                price.Property(p => p.Currency).HasMaxLength(3);
            });

            builder.ToTable("Rooms");
        }
    }
}
