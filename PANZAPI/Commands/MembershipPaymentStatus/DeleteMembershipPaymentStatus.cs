using MediatR;

namespace PANZAPI.Commands.MembershipPaymentStatus
{
    public class DeleteMembershipPaymentStatus : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
