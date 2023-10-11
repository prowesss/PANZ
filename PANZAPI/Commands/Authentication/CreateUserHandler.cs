using MediatR;
using Microsoft.AspNetCore.Identity;
using PANZAPI.Enum;
using PANZAPI.Exceptions;
using PANZAPI.Models.Authentication.SignUp;

namespace PANZAPI.Commands.Authentication
{
    public class CreateUserHandler : IRequestHandler<CreateUser, IdentityUser>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateUserHandler(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityUser> Handle(CreateUser request, CancellationToken cancellationToken)
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
            var role = RolesEnum.Member.ToString();

            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    throw new Exception("User failed to create");
                }
                //Add role to the user

                await _userManager.AddToRoleAsync(user, role);
                return user;

            }
            else
            {
                throw new Exception("This role doesnot exist");
            }
        }
    }
}
