using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class HotelDbContext(DbContextOptions<HotelDbContext> options) : DbContext(options)
{
    public virtual DbSet<Guest> Guests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
