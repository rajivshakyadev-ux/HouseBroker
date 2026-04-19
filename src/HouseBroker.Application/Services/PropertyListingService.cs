using HouseBroker.Application.DTOs;
using HouseBroker.Application.Interfaces;
using HouseBroker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HouseBroker.Application.Services;

public class PropertyListingService : IPropertyListingService
{
    private readonly IAppDbContext _context;
    private readonly IPropertyListingRepository _repository;
    private readonly ICommissionService _commissionService;

    public PropertyListingService(IAppDbContext context,IPropertyListingRepository repository, ICommissionService commissionService)
    {
        _context = context;
        _repository = repository;
        _commissionService = commissionService;
    }

    public async Task<PropertyListing> CreateAsync(CreatePropertyListingDto dto, string userId)
    {
        var property = new PropertyListing
        {
            Id = dto.Id,
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price,
            Location = dto.Location,
            PropertyListingType = dto.PropertyListingType,
            BrokerId = userId,
            CreatedAt = DateTime.UtcNow
        };

        property.CommissionAmount = await _commissionService.CalculateAsync(dto.Price);

        return await _repository.AddAsync(property);
    }

    public async Task<PropertyListing?> GetByIdAsync(int id, string userId, bool isBroker)
    {
        return await _repository.GetByIdAsync(id, userId, isBroker);
    }

    public async Task<IEnumerable<PropertyListing>> SearchAsync(PropertyListingSearchDto dto)
    {
        return await _repository.SearchAsync(dto);
    }

    public async Task<IEnumerable<PropertyListing>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}