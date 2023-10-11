using MediatR;
using Microsoft.AspNetCore.Identity;
using PANZ.Service.Models;
using PANZ.Service.Services;

namespace PANZAPI.Commands.Authentication
{
    public class ForgotPasswordHandler : IRequestHandler<ForgotPassword>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailService _emailService;

        public ForgotPasswordHandler(UserManager<IdentityUser> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;

        }

        public async Task<Unit> Handle(ForgotPassword request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var forgotPasswordlink = $"{request.Scheme}://{request.Host}/api/authentication/reset-password?token={token}&email={user.Email}";
                var message = new Message(new string[] { user.Email! }, "Forgot Password Email link", forgotPasswordlink!);
                _emailService.SendEmail(message);
            }

            else
            { 
                throw new Exception($"User with email {request.Email} not found");
               
            }
            return Unit.Value;
        }
    }
}
