namespace TaskCentral.Application.Interfaces
{
    public interface IRoleAssignService
    {
        Task<bool> AssignRoleToUserAsync(Guid userId, string roleName);
        Task<IList<string>> GetUserRolesAsync(Guid userId);
    }
}