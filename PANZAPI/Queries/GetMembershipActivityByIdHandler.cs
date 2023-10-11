using MediatR;
using PANZAPI.Models;
using PANZAPI.Repositories.MembershipActivity;

namespace PANZAPI.Queries
{
    public class GetMembershipActivityByIdHandler : IRequestHandler<GetMembershipActivityById, MembershipActivityLog>
        
    {
        private readonly IMembershipActivityRepository _activityRepo;

        public GetMembershipActivityByIdHandler(IMembershipActivityRepository activityRepo)
        {
            _activityRepo = activityRepo;
        }

        public async Task<MembershipActivityLog> Handle(GetMembershipActivityById request, CancellationToken cancellationToken)
        {
            return await _activityRepo.Find(request.LogId);
        }
    }
}
