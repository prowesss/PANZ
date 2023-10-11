using MediatR;
using Microsoft.AspNetCore.Identity;

namespace PANZAPI.Commands.Authentication
{
    public class ConfirmEmailHandler : IRequestHandler<ConfirmEmail>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ConfirmEmailHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(ConfirmEmail request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                await _userManager.ConfirmEmailAsync(user, request.Token);
                return Unit.Value;
            }
            throw new Exception("This user doesnot exist");
        }
    }
}
