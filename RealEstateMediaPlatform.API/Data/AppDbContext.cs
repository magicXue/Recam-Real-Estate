using Microsoft.EntityFrameworkCore;
using RealEstateMediaPlatform.API.Models;

namespace RealEstateMediaPlatform.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Property> Properties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Property>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);
    }
    public DbSet<ListingCase> ListingCases { get; set; }
}