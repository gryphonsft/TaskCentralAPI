using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCentral.Application.DTOs.Request;
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
        //JWT Eklenecek.
        public async Task<(bool Success, string Message, Guid? UserId)> LoginAsync(LoginUserDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);

            if (user == null)
                return (false, "Böyle bir kullanıcı bulunamadı", null);

            var result = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!result)
                return (false, "Kullanıcı adı ya da şifre hatalı", null);

            return (true, "Giriş başarılı", user.Id);
        }
    }
}
