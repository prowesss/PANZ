using MediatR;

namespace PANZAPI.Commands.MembershipActivity
{
    public class UpdateMembershipActivity : IRequest
    {
        public Guid Id { get; set; }
        public Guid MemberId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid MembershipStatusId { get; set; }
        public Guid MembershipPaymentStatusId { get; set; }
        public Guid MembershipTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
