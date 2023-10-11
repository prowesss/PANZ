using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PANZAPI.Commands.Roles
{
    public class DeleteRole : IRequest<IActionResult>
    {
        public string RoleName { get; set; }
    }

}
