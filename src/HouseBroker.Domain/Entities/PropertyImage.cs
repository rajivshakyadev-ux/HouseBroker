using System;
using System.Collections.Generic;
using System.Text;

namespace HouseBroker.Domain.Entities
{
    public class PropertyListingImage
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int PropertyListingId { get; set; }

        public PropertyListing PropertyListing { get; set; }
    }
}
