using HouseBroker.Application.DTOs;
using HouseBroker.Application.Interfaces;
using HouseBroker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HouseBroker.Infrastructure.Repositories;

public class PropertyListingRepository : IPropertyListingRepository
{
    private readonly IAppDbContext _context;

    public PropertyListingRepository(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<PropertyListing> AddAsync(PropertyListing property)
    {
        _context.Properties.Add(property);
        await _context.SaveChangesAsync();
        return property;
    }

    public async Task<PropertyListing?> GetByIdAsync(int id, string userId, bool isBroker)
    {
        return await _context.Properties
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<PropertyListing>> GetAllAsync()
    {
        return await _context.Properties.ToListAsync();
    }

    public async Task<IEnumerable<PropertyListing>> SearchAsync(PropertyListingSearchDto dto)
    {
        var query = _context.Properties.AsQueryable();

        if (!string.IsNullOrEmpty(dto.Location))
            query = query.Where(p => p.Location.Contains(dto.Location));

        // Add more search filters here...

        return await query.ToListAsync();
    }
}