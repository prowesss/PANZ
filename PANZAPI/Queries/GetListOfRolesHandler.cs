using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PANZAPI.Queries
{
    public class GetListOfRolesHandler : IRequestHandler<GetListOfRoles, IEnumerable<IdentityRole>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetListOfRolesHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<IdentityRole>> Handle(GetListOfRoles request, CancellationToken cancellationToken)
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }
    }
}
