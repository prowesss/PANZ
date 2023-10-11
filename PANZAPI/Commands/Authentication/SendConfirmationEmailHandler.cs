using MediatR;
using Microsoft.AspNetCore.Identity;
using PANZ.Service.Models;
using PANZ.Service.Services;
using System;

namespace PANZAPI.Commands.Authentication
{
    public class SendConfirmationEmailHandler : IRequestHandler<SendConfirmationEmail>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SendConfirmationEmailHandler(UserManager<IdentityUser> userManager, IEmailService emailService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
        }

        async Task<Unit> IRequestHandler<SendConfirmationEmail, Unit>.Handle(SendConfirmationEmail request, CancellationToken cancellationToken)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(request.User);
            var confirmationLink = GenerateConfirmationLinkAsync(token, request.User.Email);
            var message = new Message(new string[] { request.User.Email! }, "Confirmation Email link", confirmationLink.Result!);
            _emailService.SendEmail(message);
            return Unit.Value;
        }

        public async Task<string> GenerateConfirmationLinkAsync(string token, string email)
        {
            var scheme = _httpContextAccessor.HttpContext.Request.Scheme;
            var host = _httpContextAccessor.HttpContext.Request.Host;
            var confirmationLink = $"{scheme}://{host}/api/authentication/confirmEmail?token={token}&email={email}";
            return confirmationLink;
        }


    }
}
