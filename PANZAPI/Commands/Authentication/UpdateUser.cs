using MediatR;
using Microsoft.AspNetCore.Identity;

namespace PANZAPI.Commands.Authentication
{
    public class UpdateUser: IRequest<IdentityUser>
    {
        public string UserId { get; }
        public string UserName { get; }
        public string Email { get; }
        public string PhoneNumber { get; }

    }
}
