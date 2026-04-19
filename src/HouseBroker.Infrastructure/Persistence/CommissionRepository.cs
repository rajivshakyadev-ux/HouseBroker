using HouseBroker.Application.Interfaces;
using HouseBroker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseBroker.Infrastructure.Persistence;

public class CommissionRepository : ICommissionRepository
{
    private readonly AppDbContext _context;

    public CommissionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<decimal> GetRateByPriceAsync(decimal propertyPrice)
    {
        var rule = await _context.CommissionRules
            .OrderBy(r => r.MinPrice)
            .LastOrDefaultAsync(r => propertyPrice >= r.MinPrice);

        return rule?.CommissionRate ?? 0m;
    }
}