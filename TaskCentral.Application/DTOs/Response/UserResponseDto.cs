using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCentral.Application.DTOs.Response
{
    public sealed record UserResponseDto(
        string Username,
        string Email,
        string FullName,
        IList<string> Roles);
}
