using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Queries
{
    public class GetMembershipActivityById : IRequest<MembershipActivityLog>
    {
        public Guid LogId { get; set; }

        public GetMembershipActivityById(Guid logId)
        {
            LogId = logId;
        }
    }
}
