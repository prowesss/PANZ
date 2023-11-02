using MediatR;
using Microsoft.AspNetCore.Identity;

namespace PANZAPI.Commands.Authentication
{
    public class SendConfirmationEmail : IRequest
    {
        public IdentityUser User { get; set; }
    }
}
