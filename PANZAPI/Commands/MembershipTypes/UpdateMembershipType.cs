using MediatR;
using PANZAPI.Commands.Payment;
using PANZAPI.Models;

namespace PANZAPI.Commands.MembershipTypes
{
    public class UpdateMembershipType : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public MembershipType MembershipType { get; set; }

    }
}