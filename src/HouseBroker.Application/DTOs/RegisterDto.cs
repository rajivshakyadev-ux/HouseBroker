using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HouseBroker.Application.DTOs
{
    public class RegisterDto
    {
        [Required] // Must be inside the class, above a property
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; } // "Broker" or "Seeker"
    }
}
