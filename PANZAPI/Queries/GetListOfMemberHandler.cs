using MediatR;
using PANZAPI.Models;
using PANZAPI.ModelsSummary;
using PANZAPI.Repositories.Members;

namespace PANZAPI.Queries
{
    public class GetListOfMemberHandler : IRequestHandler<GetListOfMember, IEnumerable<MemberSummary>>
    {
        private readonly IMembersRepository _memberRepo;

        public GetListOfMemberHandler(IMembersRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public async Task<IEnumerable<MemberSummary>> Handle(GetListOfMember request, CancellationToken cancellationToken)
        {
            var members =  await _memberRepo.GetListOfMembers();

            return members.Select(x => new MemberSummary(x));
        }
    }
}
