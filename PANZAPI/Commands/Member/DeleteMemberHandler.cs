using MediatR;
using PANZAPI.Repositories.Members;

namespace PANZAPI.Commands.Member
{
    public class DeleteMemberHandler : IRequestHandler<DeleteMember, Unit>
    {
        private readonly IMembersRepository _memberRepo;

        public DeleteMemberHandler(IMembersRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public async Task<Unit> Handle(DeleteMember request, CancellationToken cancellationToken)
        {
            var existingMember = await _memberRepo.GetMemberById(request.Id);

            if (existingMember == null)
            {
                return Unit.Value;
            }
            existingMember.IsActive = false;
            await _memberRepo.UpdateMember(existingMember);
            return Unit.Value;
        }
    }
}
