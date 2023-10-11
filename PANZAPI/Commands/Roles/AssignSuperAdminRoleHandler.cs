using MediatR;
using Microsoft.AspNetCore.Identity;

namespace PANZAPI.Commands.Roles
{
    public class AssignSuperAdminRoleHandler : IRequestHandler<AssignSuperAdminRole>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AssignSuperAdminRoleHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        async Task<Unit> IRequestHandler<AssignSuperAdminRole, Unit>.Handle(AssignSuperAdminRole request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            var currentRoles = await _userManager.GetRolesAsync(user);
            var userHasSuperAdminRole = currentRoles.Contains("SuperAdmin");
            var removeRolesResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeRolesResult.Succeeded)
            {
                return Unit.Value;
            }
            var addRoleResult = await _userManager.AddToRoleAsync(user, "SuperAdmin");
            return Unit.Value;
        }
    }
}
