using MediatR;

namespace PANZAPI.Commands.MembershipPaymentStatus
{
    public class UpdateMembershipPaymentStatus : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
