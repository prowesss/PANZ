using MediatR;
using PANZAPI.ModelsSummary;
using PANZAPI.Repositories.Members;

namespace PANZAPI.Queries
{
    public class GetMembershipDetailsByUserIDHandler : IRequestHandler<GetMembershipDetailsByUserID, MemberSummary>
    {
        private readonly IMembersRepository _memberRepo;

        public GetMembershipDetailsByUserIDHandler(IMembersRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }
        public async Task<MemberSummary> Handle(GetMembershipDetailsByUserID request, CancellationToken cancellationToken)
        {
            var member = await _memberRepo.GetMembershipDetailsByUserId(request.UserId);
            if (member == null) { return null; }
            return new MemberSummary(member);
        }
    } 
}
