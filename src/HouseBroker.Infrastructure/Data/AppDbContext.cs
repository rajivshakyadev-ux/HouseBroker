using Microsoft.EntityFrameworkCore;
using HouseBroker.Application.Interfaces;
using HouseBroker.Domain.Entities;

namespace HouseBroker.Infrastructure.Data;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<CommissionRule> CommissionRules { get; set; }
    public DbSet<PropertyListing> Properties { get; set; }
    public DbSet<PropertyListingImage> PropertyListingImages { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PropertyListingImage>()
            .HasOne(x => x.PropertyListing)
            .WithMany(x => x.Images)
            .HasForeignKey(x => x.PropertyListingId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<PropertyListing>()
            .Property(x => x.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<PropertyListing>()
            .Property(x => x.BrokerCommission)
            .HasPrecision(18, 2);

        modelBuilder.Entity<PropertyListing>()
            .Property(x => x.CommissionAmount)
            .HasPrecision(18, 2);
        modelBuilder.Entity<CommissionRule>()
            .Property(x => x.MinPrice)
            .HasPrecision(18, 2);

        modelBuilder.Entity<CommissionRule>()
            .Property(x => x.MaxPrice)
            .HasPrecision(18, 2);

        modelBuilder.Entity<CommissionRule>()
            .Property(x => x.CommissionRate)
            .HasPrecision(5, 2);

        modelBuilder.Entity<CommissionRule>()
            .Property(x => x.Percentage)
            .HasPrecision(5, 2);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}