using MediatR;

namespace PANZAPI.Commands.Member
{
    public class CreateMemberPayment : IRequest
    {
        public string PaymentMethodName { get; set; }
        public Guid MemberId { get; set;}
        public string? PaymentReference { get; set;}
        public string? PaymentSessionId { get; set; }
    }
}
