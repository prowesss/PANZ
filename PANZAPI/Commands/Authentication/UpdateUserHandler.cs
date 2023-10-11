using MediatR;
using Microsoft.AspNetCore.Identity;

namespace PANZAPI.Commands.Authentication
{
    public class UpdateUserHandler : IRequestHandler<UpdateUser, IdentityUser>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UpdateUserHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityUser> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user != null)
            {
                user.UserName = request.UserName;
                user.Email = request.Email;
                user.PhoneNumber = request.PhoneNumber;
                var result = await _userManager.UpdateAsync(user);
                if(result.Errors.Count() > 0)
                {
                    throw new Exception("Failed to update the user");
                }
                return user;
            }
            throw new Exception("User not found");
        }
    }
}
