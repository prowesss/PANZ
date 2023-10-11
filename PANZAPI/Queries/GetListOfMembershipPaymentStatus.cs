using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Queries
{
    public class GetListOfMembershipPaymentStatus : IRequest<IEnumerable<MembershipPaymentStatus>>
    {
    }
}
