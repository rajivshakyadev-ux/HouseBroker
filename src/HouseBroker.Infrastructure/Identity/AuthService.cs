using HouseBroker.Application.DTOs;
using HouseBroker.Application.Interfaces;
using HouseBroker.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HouseBroker.Infrastructure.Identity
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        public AuthService(UserManager<ApplicationUser> userManager,
                       IJwtTokenService jwtTokenService,
                       IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _passwordHasher = passwordHasher;
        }
        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, dto.Role);
                return _jwtTokenService.GenerateToken(user, dto.Role);
            }

            var errorMessages = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"Registration failed: {errorMessages}");
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) return null;

            var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (verificationResult == PasswordVerificationResult.Success)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault() ?? "HouseSeeker";

                return _jwtTokenService.GenerateToken(user, role);
            }

            return null;
        }

    }
}
