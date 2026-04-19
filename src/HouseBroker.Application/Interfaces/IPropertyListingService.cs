using HouseBroker.Application.DTOs;
using HouseBroker.Domain.Entities;

namespace HouseBroker.Application.Interfaces
{
    public interface IPropertyListingService
    {
        Task<PropertyListing> CreateAsync(CreatePropertyListingDto dto, string userId);
        Task<IEnumerable<PropertyListing>> GetAllAsync();
        Task<IEnumerable<PropertyListing>> SearchAsync(PropertyListingSearchDto dto);
        Task<PropertyListing?> GetByIdAsync(int id, string userId, bool isBroker);
    }
}
