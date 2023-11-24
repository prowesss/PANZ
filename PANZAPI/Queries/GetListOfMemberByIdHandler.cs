using MediatR;
using PANZAPI.Models;
using PANZAPI.ModelsSummary;
using PANZAPI.Repositories.Members;

namespace PANZAPI.Queries
{
    public class GetListOfMemberByIdHandler : IRequestHandler<GetListOfMemberById, MemberSummary>
    {
        private readonly IMembersRepository _memberRepo;

        public GetListOfMemberByIdHandler(IMembersRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }
        public async Task<MemberSummary> Handle(GetListOfMemberById request, CancellationToken cancellationToken)
        {
            var member = await _memberRepo.GetMemberById(request.Id);
            if (member == null) { return null; }
            return new MemberSummary(member);
        }
    }
}
