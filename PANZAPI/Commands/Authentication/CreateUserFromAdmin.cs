using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PANZAPI.Commands.Authentication
{
    public class CreateUserFromAdmin : IRequest<IdentityUser>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
