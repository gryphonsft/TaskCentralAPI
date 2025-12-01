using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskCentral.Application.DTOs.Request;
using TaskCentral.Application.DTOs.Response;
using TaskCentral.Application.Interfaces;
using TaskCentral.Domain.User;

namespace TaskCentral.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        #region User authentication servisi
        public async Task<(bool Success, string Message, Guid? UserId, string? Token)> LoginAsync(LoginUserDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);

            if (user == null)
                return (false, "Böyle bir kullanıcı bulunamadı", null, null);

            var result = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!result)
                return (false, "Kullanıcı adı ya da şifre hatalı", null, null);

            var roles = await _userManager.GetRolesAsync(user);

            var token = GenerateJwtToken(user, roles);

            return (true, "Giriş başarılı", user.Id, token);
        }

        public async Task<(bool Success, string Message)> RegisterAsync(RegisterUserDto dto)
        {
            var existingUser = await _userManager.FindByNameAsync(dto.Username);

            if (existingUser != null)
                return (false, "Bu kullanıcı adı zaten alınmış");

            var user = new AppUser
            {
                UserName = dto.Username,
                Email = dto.Email,
                FullName = dto.FullName
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return (false, errors);
            }

            return (true, "Kullanıcı başarıyla oluşturuldu.");
        }

        // GetAllUser , GetAllUserDetail

        public async Task<IEnumerable<UserResponseDto>> GetAllUserDetailsAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            var response = new List<UserResponseDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                response.Add(new UserResponseDto(
                    user.UserName ?? string.Empty,
                    user.Email ?? string.Empty,
                    user.FullName,
                    roles.ToList()
                ));
            }
            return response;
        }


        #endregion

        #region Jwt oluşturma Servisi
        private string GenerateJwtToken(AppUser user, IList<string> roles)
        {
            var keyString = _configuration["Jwt:Key"]
                ?? throw new Exception("JWT Key missing in configuration");

            var issuer = _configuration["Jwt:Issuer"]
                ?? throw new Exception("JWT Issuer missing");

            var audience = _configuration["Jwt:Audience"]
                ?? throw new Exception("JWT Audience missing");

            var expireTime = _configuration["Jwt:ExpireTime"]
                ?? throw new Exception("JWT ExpireTime missing");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName ?? ""),
                new Claim("fullname", user.FullName ?? "")
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(expireTime)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}
