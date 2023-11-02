using MediatR;
using PANZAPI.Models;
using PANZAPI.Repositories.MembershipStatuses;

namespace PANZAPI.Queries
{
    public class GetMembershipStatusByIdHandler : IRequestHandler<GetMembershipStatusById, MembershipStatus>
    {
        private readonly IMembershipStatusRepository _membershipStatusRepository;

        public GetMembershipStatusByIdHandler(IMembershipStatusRepository membershipStatusRepository)
        {
            _membershipStatusRepository = membershipStatusRepository;
        }

        public async Task<MembershipStatus> Handle(GetMembershipStatusById request, CancellationToken cancellationToken)
        {
            return await _membershipStatusRepository.GetMembershipStatusByIdAsync(request.Id);
        }
    }
}
