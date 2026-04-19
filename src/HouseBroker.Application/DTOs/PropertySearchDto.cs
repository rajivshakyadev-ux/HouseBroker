using System;
using System.Collections.Generic;
using System.Text;

namespace HouseBroker.Application.DTOs
{
    public class PropertyListingSearchDto
    {
        public string? Location { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? PropertyListingType { get; set; }
    }
}
