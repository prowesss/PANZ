using MediatR;
using Microsoft.AspNetCore.Identity;

namespace PANZAPI.Commands.Roles
{
    public class CreateRole : IRequest<IdentityRole>
    {
        public string RoleName { get; set; }
    }
}
