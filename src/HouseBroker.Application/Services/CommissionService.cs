using HouseBroker.Application.Interfaces;

namespace HouseBroker.Application.Services;

public class CommissionService : ICommissionService
{
    private readonly ICommissionRepository _repository;

    public CommissionService(ICommissionRepository repository)
    {
        _repository = repository;
    }

    public async Task<decimal> CalculateAsync(decimal propertyPrice)
    {
        var rate = await _repository.GetRateByPriceAsync(propertyPrice);
        return propertyPrice * rate;
    }
}