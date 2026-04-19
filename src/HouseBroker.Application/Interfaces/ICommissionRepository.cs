using HouseBroker.Domain.Entities;

namespace HouseBroker.Application.Interfaces;

public interface ICommissionRepository
{
    Task<decimal> GetRateByPriceAsync(decimal propertyPrice);
    //Task<decimal> GetRates(decimal propertyPrice);
    //Task<decimal> GetCommissionRateAsync(int propertyId);
    //Task<CommissionRates> GetConfiguredRatesAsync();
}