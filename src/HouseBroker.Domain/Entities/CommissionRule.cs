using System;
using System.Collections.Generic;
using System.Text;

namespace HouseBroker.Domain.Entities
{
    public class CommissionRule
    {
        public Guid Id { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal Percentage { get; set; }
        public decimal CommissionRate { get; set; }
    }
}
