using MediatR;
using PANZAPI.Models;
using PANZAPI.Repositories.MembershipTypes;

namespace PANZAPI.Commands.MembershipTypes
{
    public class CreateMembershipTypeHandler : IRequestHandler<CreateMembershipType, Guid>
    {
        private readonly IMembershipTypeRepository _membershipTypeRepository;

        public CreateMembershipTypeHandler(IMembershipTypeRepository membershipTypeRepository)
        {
            _membershipTypeRepository = membershipTypeRepository;
        }

        public async Task<Guid> Handle(CreateMembershipType request, CancellationToken cancellationToken)
        {
            return await _membershipTypeRepository.CreateMembershipTypeAsync(request.MembershipType);
        }
    }

}
