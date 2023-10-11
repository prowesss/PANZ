using MediatR;
using PANZAPI.Repositories.MembershipStatuses;

namespace PANZAPI.Commands.MembershipStats
{
    public class UpdateMembershipStatusHandler : IRequestHandler<UpdateMembershipStatus, Unit>
    {
        private readonly IMembershipStatusRepository _membershipStatusRepository;

        public UpdateMembershipStatusHandler(IMembershipStatusRepository membershipStatusRepository)
        {
            _membershipStatusRepository = membershipStatusRepository;
        }

        public async Task<Unit> Handle(UpdateMembershipStatus request, CancellationToken cancellationToken)
        {
            await _membershipStatusRepository.UpdateMembershipStatusAsync(request.Id, request.MembershipStatus);
            return Unit.Value;
        }
    }

}
