using MediatR;
using PANZAPI.Models;
using PANZAPI.ModelsSummary;
using PANZAPI.Repositories.MembershipActivity;

namespace PANZAPI.Queries
{
    public class GetListOfMembershipTypeHandler : IRequestHandler<GetListOfMembershipType, IEnumerable<MembershipActivityLog>>
    {
        private readonly IMembershipActivityRepository _activityRepo;

        public GetListOfMembershipTypeHandler(IMembershipActivityRepository activityRepo)
        {
            _activityRepo = activityRepo;
        }
        public async Task<IEnumerable<MembershipActivityLog>> Handle(GetListOfMembershipType request, CancellationToken cancellationToken)
        {
            var activity = await _activityRepo.GetList();
            return activity;
        }
    }
}
