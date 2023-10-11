using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Queries
{
    public class GetListOfMembership : IRequest<IEnumerable<MembershipType>>
    {
    }

}
