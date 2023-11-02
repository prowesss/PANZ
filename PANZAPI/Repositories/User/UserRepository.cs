using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PANZAPI.ModelsSummary;

namespace PANZAPI.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<IdentityUser>> GetListOfUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<IdentityUser> GetUserById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<IdentityUser> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityUser> AddUser(IdentityUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
            return user;
        }

        public async Task<IdentityUser> AddUserToRole(IdentityUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
            return user;
        }

        public async Task<IdentityUser> UpdateUser(IdentityUser user)
        {
            await _userManager.UpdateAsync(user);
            return user;
        }
    }
}
