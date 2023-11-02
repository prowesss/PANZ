using MediatR;
using Microsoft.EntityFrameworkCore;
using PANZAPI.Models;
using PANZAPI.Repositories.MembershipTypes;

namespace PANZAPI.Commands.MembershipTypes
{
    public class UpdateMembershipTypeCommandHandler : IRequestHandler<UpdateMembershipType, Unit>
    {
        private readonly IMembershipTypeRepository _membershipTypeRepository;

        public UpdateMembershipTypeCommandHandler(IMembershipTypeRepository membershipTypeRepository)
        {
            _membershipTypeRepository = membershipTypeRepository;
        }

        public async Task<Unit> Handle(UpdateMembershipType request, CancellationToken cancellationToken)
        {
            await _membershipTypeRepository.UpdateMembershipTypeAsync(request.Id, request.MembershipType);
            return Unit.Value;
        }
    }

}
