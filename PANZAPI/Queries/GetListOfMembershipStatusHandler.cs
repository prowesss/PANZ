using MediatR;
using Microsoft.EntityFrameworkCore;
using PANZAPI.Models;
using PANZAPI.ModelsSummary;
using PANZAPI.Repositories.MembershipStatuses;

namespace PANZAPI.Queries
{
    public class GetListOfMembershipStatusHandler : IRequestHandler<GetListOfMembershipStatus, IEnumerable<MembershipStatusSummary>>
    {
        private readonly IMembershipStatusRepository _membershipStatusRepository;

        public GetListOfMembershipStatusHandler(IMembershipStatusRepository membershipStatusRepository)
        {
            _membershipStatusRepository = membershipStatusRepository;
        }

        public async Task<IEnumerable<MembershipStatusSummary>> Handle(GetListOfMembershipStatus request, CancellationToken cancellationToken)
        {
            var membershipStatus =  await _membershipStatusRepository.GetMembershipStatuses();
            return membershipStatus.Select(x => new MembershipStatusSummary(x));
        }
    }

}
