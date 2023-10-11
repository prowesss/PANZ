using MediatR;

namespace PANZAPI.Commands.MembershipPaymentStatus
{
    public class CreateMembershipPaymentStatus : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
