using HouseBroker.Application.DTOs;
using HouseBroker.Domain.Entities;

namespace HouseBroker.Application.Interfaces
{
    public interface IPropertyListingRepository
    {
        Task<PropertyListing> AddAsync(PropertyListing property);
        Task<PropertyListing?> GetByIdAsync(int id, string userId, bool isBroker);
        Task<IEnumerable<PropertyListing>> GetAllAsync();
        Task<IEnumerable<PropertyListing>> SearchAsync(PropertyListingSearchDto dto);
    }
}
