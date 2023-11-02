using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PANZAPI.Repositories.Role;

namespace PANZAPI.Commands.Roles
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRole, IActionResult>
    {
        private readonly IRoleRepository _roleRepository;

        public UpdateRoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IActionResult> Handle(UpdateRole request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetRoleByNameAsync(request.OldRoleName);

            if (role == null)
            {
                return new NotFoundObjectResult($"Role {request.OldRoleName} not found");
            }

            role.Name = request.NewRoleName;

            var success = await _roleRepository.UpdateRoleAsync(role);

            if (success)
            {
                return new OkObjectResult($"Role {request.OldRoleName} updated to {request.NewRoleName} successfully");
            }

            return new BadRequestObjectResult($"Error updating role");
        }
    }
}
