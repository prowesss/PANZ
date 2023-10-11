using MediatR;
using PANZAPI.Models;
using PANZAPI.Repositories.Members;

namespace PANZAPI.Queries
{
    public class GetListOfMemberHandler : IRequestHandler<GetListOfMember, IEnumerable<Member>>
    {
        private readonly IMembersRepository _memberRepo;

        public GetListOfMemberHandler(IMembersRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public async Task<IEnumerable<Member>> Handle(GetListOfMember request, CancellationToken cancellationToken)
        {
            return await _memberRepo.GetListOfMembers();
        }
    }
}
