using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCentral.Domain.Role;
using TaskCentral.Domain.User;

namespace TaskCentral.Application.Services
{
    public class RoleAssignService 
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAssignService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        
        //public async Task<bool> AssignRoleToUserAsync(Guid userId, string roleName)
        //{

        //}
    }
}
