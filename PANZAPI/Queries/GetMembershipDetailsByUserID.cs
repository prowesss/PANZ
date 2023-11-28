using MediatR;
using PANZAPI.ModelsSummary;

namespace PANZAPI.Queries
{
    public class GetMembershipDetailsByUserID : IRequest<MemberSummary>
    {
        public string UserId { get; }

        public GetMembershipDetailsByUserID(string userId)
        {
            UserId = userId;
        }
    }
}
