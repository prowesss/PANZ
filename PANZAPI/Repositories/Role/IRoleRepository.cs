using Microsoft.AspNetCore.Identity;

namespace PANZAPI.Repositories.Role
{
    public interface IRoleRepository
    {
        Task<bool> RoleExistsAsync(string roleName);
        Task<IdentityRole> CreateRoleAsync(string roleName);
        Task<IdentityRole> GetRoleByNameAsync(string roleName);
        Task<bool> UpdateRoleAsync(IdentityRole role);
        Task<bool> DeleteRoleAsync(string roleName);
        Task<IEnumerable<IdentityRole>> GetAllRolesAsync();
        Task<IdentityRole> GetRoleByIdAsync(string roleId);
    }
}
