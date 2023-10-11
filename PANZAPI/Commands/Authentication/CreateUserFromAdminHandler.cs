using MediatR;
using Microsoft.AspNetCore.Identity;
using PANZAPI.Exceptions;

namespace PANZAPI.Commands.Authentication
{
    public class CreateUserFromAdminHandler : IRequestHandler<CreateUserFromAdmin, IdentityUser>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateUserFromAdminHandler(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        async Task<IdentityUser> IRequestHandler<CreateUserFromAdmin, IdentityUser>.Handle(CreateUserFromAdmin request, CancellationToken cancellationToken)
        {
            return await RegisterUserFromAdmin(request);
        }

        private async Task<IdentityUser> RegisterUserFromAdmin(CreateUserFromAdmin request)
        {
            var userExist = await _userManager.FindByEmailAsync(request.Email);
            if (userExist != null)
            {
                throw new ForbiddenException("User Already exists!");
            }

            IdentityUser user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Email
            };

            if (await _roleManager.RoleExistsAsync(request.Role))
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    throw new Exception("User failed to create");
                }
                //Add role to the user
                await _userManager.AddToRoleAsync(user, request.Role);
                return user;
            }
            else
            {
                throw new Exception("This role doesnot exist");
            }
        }
    }
}
