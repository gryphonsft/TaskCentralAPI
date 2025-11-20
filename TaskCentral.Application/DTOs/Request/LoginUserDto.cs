using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCentral.Application.DTOs.Request
{
    public sealed record LoginUserDto(string Username, string Password);
}
