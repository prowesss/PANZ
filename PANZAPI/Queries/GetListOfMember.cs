using MediatR;
using PANZAPI.Models;
using PANZAPI.ModelsSummary;

namespace PANZAPI.Queries
{
    public class GetListOfMember : IRequest<IEnumerable<MemberSummary>>
    {
    }
}
