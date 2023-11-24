using MediatR;
using PANZAPI.Models;
using PANZAPI.ModelsSummary;

namespace PANZAPI.Queries
{
    public class GetListOfMembershipStatus : IRequest<IEnumerable<MembershipStatusSummary>>
    {
    }

}
