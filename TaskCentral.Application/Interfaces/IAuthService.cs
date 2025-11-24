using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCentral.Application.DTOs.Request;

namespace TaskCentral.Application.Interfaces
{
    public interface IAuthService
    {
        #region User authentication servisi
        Task<(bool Success, string Message, Guid? UserId, string? Token)> LoginAsync(LoginUserDto dto);
        Task<(bool Success, string Message)> RegisterAsync(RegisterUserDto dto);
        #endregion
    }
}
