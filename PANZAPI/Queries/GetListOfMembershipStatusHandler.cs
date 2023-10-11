using MediatR;
using Microsoft.EntityFrameworkCore;
using PANZAPI.Models;
using PANZAPI.Repositories.MembershipStatuses;

namespace PANZAPI.Queries
{
    public class GetListOfMembershipStatusHandler : IRequestHandler<GetListOfMembershipStatus, IEnumerable<MembershipStatus>>
    {
        private readonly IMembershipStatusRepository _membershipStatusRepository;

        public GetListOfMembershipStatusHandler(IMembershipStatusRepository membershipStatusRepository)
        {
            _membershipStatusRepository = membershipStatusRepository;
        }

        public async Task<IEnumerable<MembershipStatus>> Handle(GetListOfMembershipStatus request, CancellationToken cancellationToken)
        {
            return await _membershipStatusRepository.GetMembershipStatusesAsync();
        }
    }

}
