using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCentral.Application.Interfaces;
using TaskCentral.Domain.Role;
using TaskCentral.Domain.User;

namespace TaskCentral.Application.Services
{
    public class RoleAssignService : IRoleAssignService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAssignService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        
        public async Task<bool> AssignRoleToUserAsync(Guid userId, string roleName)
        {
            // Kullanıcı kontrolü, string'e convert ediliyor
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if(user == null)
            
                throw new Exception("Böyle bir kullanici bulunamadi");
            
            if(!await _roleManager.RoleExistsAsync(roleName))
                throw new Exception("Böyle bir rol bulunamadi.");
            // Kullanıcı eğer zaten bu role sahipse
            if(await _userManager.IsInRoleAsync(user,roleName))
                return true; // Rolü zaten var ise

            var result = await _userManager.AddToRoleAsync(user,roleName);

            return result.Succeeded; 
        }
        public async Task<IList<string>> GetUserRolesAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            
            if (user == null)
                throw new Exception("Böyle bir kullanici bulunamadi");
            return await _userManager.GetRolesAsync(user);
        }
    }
}
