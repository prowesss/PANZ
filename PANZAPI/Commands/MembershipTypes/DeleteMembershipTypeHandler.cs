using MediatR;
using PANZAPI.Models;
using PANZAPI.Repositories.MembershipTypes;

namespace PANZAPI.Commands.MembershipTypes
{
    public class DeleteMembershipTypeHandler : IRequestHandler<DeleteMembershipType, Unit>
    {
        private readonly IMembershipTypeRepository _membershipTypeRepository;

        public DeleteMembershipTypeHandler(IMembershipTypeRepository membershipTypeRepository)
        {
            _membershipTypeRepository = membershipTypeRepository;
        }

        public async Task<Unit> Handle(DeleteMembershipType request, CancellationToken cancellationToken)
        {
            await _membershipTypeRepository.DeleteMembershipTypeAsync(request.Id);
            return Unit.Value;
        }
    }

}
