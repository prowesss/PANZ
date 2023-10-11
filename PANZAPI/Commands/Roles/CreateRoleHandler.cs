using MediatR;
using Microsoft.AspNetCore.Identity;
using PANZAPI.Exceptions;
using PANZAPI.Repositories.Role;

namespace PANZAPI.Commands.Roles
{
    public class CreateRoleHandler : IRequestHandler<CreateRole, IdentityRole>
    {
        private readonly IRoleRepository _roleRepository;

        public CreateRoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IdentityRole> Handle(CreateRole request, CancellationToken cancellationToken)
        {
            var roleExists = await _roleRepository.RoleExistsAsync(request.RoleName);
            if (roleExists)
            {
                throw new ForbiddenException("Role Already exists!");
            }

            return await _roleRepository.CreateRoleAsync(request.RoleName);
        }

    }
}