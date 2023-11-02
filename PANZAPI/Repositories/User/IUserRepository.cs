using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PANZAPI.ModelsSummary;

namespace PANZAPI.Repositories.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetListOfUsers();
        Task<IdentityUser> UpdateUser(IdentityUser user);
        Task<IdentityUser> AddUser(IdentityUser user, string password);
        Task<IdentityUser> GetUserByEmail(string email);
        Task<IdentityUser> GetUserById(string userId);
    }
}
