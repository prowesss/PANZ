using MediatR;
using PANZAPI.Repositories.MembershipStatuses;

namespace PANZAPI.Commands.MembershipStats
{
    public class DeleteMembershipStatusCommandHandler : IRequestHandler<DeleteMembershipStatus, Unit>
    {
        private readonly IMembershipStatusRepository _membershipStatusRepository;

        public DeleteMembershipStatusCommandHandler(IMembershipStatusRepository membershipStatusRepository)
        {
            _membershipStatusRepository = membershipStatusRepository;
        }

        public async Task<Unit> Handle(DeleteMembershipStatus request, CancellationToken cancellationToken)
        {
            await _membershipStatusRepository.DeleteMembershipStatusAsync(request.Id);
            return Unit.Value;
        }
    }

}
