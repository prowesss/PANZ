using MediatR;
using Microsoft.AspNetCore.Identity;

namespace PANZAPI.Commands.Authentication
{
    public class CreateUser : IRequest<IdentityUser>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
