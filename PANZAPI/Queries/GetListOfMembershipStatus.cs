using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Queries
{
    public class GetListOfMembershipStatus : IRequest<IEnumerable<MembershipStatus>>
    {
    }

}
