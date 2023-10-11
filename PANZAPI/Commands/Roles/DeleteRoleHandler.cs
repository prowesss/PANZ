using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PANZAPI.Repositories.Role;

namespace PANZAPI.Commands.Roles
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRole, IActionResult>
    {
        private readonly IRoleRepository _roleRepository;

        public DeleteRoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IActionResult> Handle(DeleteRole request, CancellationToken cancellationToken)
        {
            var success = await _roleRepository.DeleteRoleAsync(request.RoleName);

            if (success)
            {
                return new OkObjectResult($"Role {request.RoleName} deleted successfully");
            }

            return new NotFoundObjectResult($"Role {request.RoleName} not found");
        }
    }

}
