using MediatR;
using PANZAPI.Models;
using PANZAPI.ModelsSummary;

namespace PANZAPI.Queries
{
    public class GetListOfMemberById : IRequest<MemberSummary>
    {
        public Guid Id { get; set; }

        public GetListOfMemberById(Guid id)
        {
            Id = id;
        }
    }
}
