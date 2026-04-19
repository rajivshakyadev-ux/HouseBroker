using System;
using System.Collections.Generic;
using System.Text;

namespace HouseBroker.Domain.Entities
{
    public class CommissionRates
    {
        public decimal Tier1Rate { get; set; } = 0.02m;
        public decimal Tier2Rate { get; set; } = 0.0175m;
        public decimal Tier3Rate { get; set; } = 0.015m;
        public decimal Tier1Limit { get; set; } = 5000000m;
        public decimal Tier2Limit { get; set; } = 10000000m; 
        public int Id { get; set; }
        public decimal Low { get; set; }
        public decimal Medium { get; set; }
        public decimal High { get; set; }
        public decimal Premium { get; set; }
    }
}
