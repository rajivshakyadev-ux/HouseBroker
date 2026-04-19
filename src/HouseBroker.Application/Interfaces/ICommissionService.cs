using System;
using System.Collections.Generic;
using System.Text;

namespace HouseBroker.Application.Interfaces
{
    public interface ICommissionService
    {
        Task<decimal> CalculateAsync(decimal propertyPrice);
        //Task<decimal> CalculateCommissionAsync(decimal propertyPrice);
    }
}
