using MediatR;

namespace PANZAPI.Commands.Roles
{
    public class AssignSuperAdminRole : IRequest
    {
        public string UserId { get; set; }
    }

}
