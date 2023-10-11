using MediatR;
using Microsoft.AspNetCore.Identity;

namespace PANZAPI.Commands.Authentication
{
    public class ResetUserPasswordHandler : IRequestHandler<ResetUserPassword>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ResetUserPasswordHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(ResetUserPassword request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                var resetPassResult = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);
                if (!resetPassResult.Succeeded)
                {
                    var errors = resetPassResult.Errors.Select(error => new KeyValuePair<string, string>(error.Code, error.Description));
                }

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}
