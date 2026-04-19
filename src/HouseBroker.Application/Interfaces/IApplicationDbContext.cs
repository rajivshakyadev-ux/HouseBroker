using HouseBroker.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace HouseBroker.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<CommissionRule> CommissionRules { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<PropertyListing> Properties { get; }
        DbSet<PropertyListingImage> PropertyListingImages { get; }
    }
}
