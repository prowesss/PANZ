using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Queries
{
    public class GetMembershipStatusById : IRequest<MembershipStatus>
    {
        public Guid Id { get; set; }
    }
}
