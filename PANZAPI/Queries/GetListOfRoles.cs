using MediatR;
using Microsoft.AspNetCore.Identity;

namespace PANZAPI.Queries
{
    public class GetListOfRoles : IRequest<IEnumerable<IdentityRole>>
    {
    }
}
