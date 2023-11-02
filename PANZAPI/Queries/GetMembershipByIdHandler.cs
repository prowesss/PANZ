using MediatR;
using PANZAPI.Models;
using PANZAPI.Repositories.MembershipTypes;

namespace PANZAPI.Queries
{
    public class GetMembershipByIdHandler : IRequestHandler<GetMembershipById, MembershipType>
    {
        private readonly IMembershipTypeRepository _membershipTypeRepository;

        public GetMembershipByIdHandler(IMembershipTypeRepository membershipTypeRepository)
        {
            _membershipTypeRepository = membershipTypeRepository;
        }

        public async Task<MembershipType> Handle(GetMembershipById request, CancellationToken cancellationToken)
        {
            return await _membershipTypeRepository.GetMembershipTypeByIdAsync(request.Id);
        }
    }

}
