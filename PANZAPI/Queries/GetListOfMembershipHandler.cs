using MediatR;
using Microsoft.EntityFrameworkCore;
using PANZAPI.Models;
using PANZAPI.Repositories.MembershipTypes;

namespace PANZAPI.Queries
{
    public class GetListOfMembershipHandler : IRequestHandler<GetListOfMembership, IEnumerable<MembershipType>>
    {
        private readonly IMembershipTypeRepository _membershipTypeRepository;

        public GetListOfMembershipHandler(IMembershipTypeRepository membershipTypeRepository)
        {
            _membershipTypeRepository = membershipTypeRepository;
        }

        public async Task<IEnumerable<MembershipType>> Handle(GetListOfMembership request, CancellationToken cancellationToken)
        {
            return await _membershipTypeRepository.GetMembershipTypesAsync();
        }
    }

}
