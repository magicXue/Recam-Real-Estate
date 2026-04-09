using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateMediaPlatform.API.Models;

namespace RealEstateMediaPlatform.API.Data;

public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Property> Properties { get; set; }
    public DbSet<ListingCase> ListingCases { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<StatusHistory> StatusHistories { get; set; }
    public DbSet<Agent> Agents { get; set; }
    public DbSet<MediaAsset> MediaAssets { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Property>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);
    }

}