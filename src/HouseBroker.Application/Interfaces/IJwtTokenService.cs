using HouseBroker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseBroker.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(ApplicationUser user, string role);
    }
}
