using MediatR;
using Microsoft.AspNetCore.Identity;
using PANZAPI.ModelsSummary;

namespace PANZAPI.Queries
{
    public class GetListOfUsers : IRequest<IEnumerable<UserSummary>>
    {
    }
}
