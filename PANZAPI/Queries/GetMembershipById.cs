using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Queries
{
    public class GetMembershipById : IRequest<MembershipType>
    {
        public Guid Id { get; set; }
    }

}
