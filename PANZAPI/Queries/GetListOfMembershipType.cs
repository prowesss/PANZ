using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Queries
{
    public class GetListOfMembershipType : IRequest<IEnumerable<MembershipActivityLog>>
    {
    }
}
