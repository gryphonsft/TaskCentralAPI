using Microsoft.AspNetCore.Identity;

namespace TaskCentral.Domain.User
{
    public sealed class AppUser : IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;
    }
}