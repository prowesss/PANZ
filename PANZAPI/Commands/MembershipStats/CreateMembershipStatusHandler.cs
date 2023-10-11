using MediatR;
using PANZAPI.Repositories.MembershipStatuses;

namespace PANZAPI.Commands.MembershipStats
{
    public class CreateMembershipStatusHandler : IRequestHandler<CreateMembershipStatus, Guid>
    {
        private readonly IMembershipStatusRepository _membershipStatusRepository;

        public CreateMembershipStatusHandler(IMembershipStatusRepository membershipStatusRepository)
        {
            _membershipStatusRepository = membershipStatusRepository;
        }

        public async Task<Guid> Handle(CreateMembershipStatus request, CancellationToken cancellationToken)
        {
            return await _membershipStatusRepository.CreateMembershipStatusAsync(request.MembershipStatus);
        }
    }

}
