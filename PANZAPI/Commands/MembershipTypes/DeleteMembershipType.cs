using MediatR;

namespace PANZAPI.Commands.MembershipTypes
{
    public class DeleteMembershipType : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }

}
