using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Commands.MembershipStats
{
    public class UpdateMembershipStatus : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public MembershipStatus MembershipStatus { get; set; }
    }
}
