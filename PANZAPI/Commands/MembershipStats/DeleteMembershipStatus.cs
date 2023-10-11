using MediatR;

namespace PANZAPI.Commands.MembershipStats
{
    public class DeleteMembershipStatus : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
