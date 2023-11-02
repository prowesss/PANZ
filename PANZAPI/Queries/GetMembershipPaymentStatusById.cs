using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Queries
{
    public class GetMembershipPaymentStatusById : IRequest<MembershipPaymentStatus>
    {
        public Guid Id { get; set; }
    }
}
