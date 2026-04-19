using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace HouseBroker.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string RoleType { get; set; } // "Broker" or "Seeker"
    }
}
