using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HouseBroker.Application.DTOs
{
    public class CreatePropertyListingDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; } = string.Empty;
        public string PropertyListingType { get; set; } = string.Empty;
        public string Features { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
