using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Queries
{
    public class GetListOfMemberById : IRequest<Member>
    {
        public Guid Id { get; set; }

        public GetListOfMemberById(Guid Id)
        {
            Id = Id;
        }
    }
}
