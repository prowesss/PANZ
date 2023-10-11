using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Queries
{
    public class GetListOfMember : IRequest<IEnumerable<Member>>
    {
    }
}
