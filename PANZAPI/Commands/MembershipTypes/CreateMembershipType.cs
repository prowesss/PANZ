using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Commands.MembershipTypes
{
    public class CreateMembershipType : IRequest<Guid>
    {
        public MembershipType MembershipType { get; set; }
    }

}
