using MediatR;

namespace PANZAPI.Commands.Member
{
    public class DeleteMember : IRequest
    {
        public Guid Id { get; set; }
    }
}
