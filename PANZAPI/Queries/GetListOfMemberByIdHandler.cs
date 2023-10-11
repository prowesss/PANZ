using MediatR;
using PANZAPI.Models;
using PANZAPI.Repositories.Members;

namespace PANZAPI.Queries
{
    public class GetListOfMemberByIdHandler : IRequestHandler<GetListOfMemberById, Member>
    {
        private readonly IMembersRepository _memberRepo;

        public GetListOfMemberByIdHandler(IMembersRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }
        public async Task<Member> Handle(GetListOfMemberById request, CancellationToken cancellationToken)
        {
            return await _memberRepo.GetMemberById(request.Id);
        }
    }
}
