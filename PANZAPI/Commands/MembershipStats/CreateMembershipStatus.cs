using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Commands.MembershipStats
{
    public class CreateMembershipStatus:IRequest<Guid>
    {
        public MembershipStatus MembershipStatus { get; set; }
    }
}
