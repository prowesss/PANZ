using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PANZAPI.Commands.Roles
{
    public class UpdateRole :IRequest<IActionResult>
    {
        public string OldRoleName { get; set; }
        public string NewRoleName { get; set; }
    }
}
