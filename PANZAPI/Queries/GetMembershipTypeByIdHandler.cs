using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Queries
{
    public class GetMembershipTypeByIdHandler : IRequestHandler<GetMembershipById, MembershipType>
    {
        private readonly ApplicationDbContext _context;

        public GetMembershipTypeByIdHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MembershipType> Handle(GetMembershipById request, CancellationToken cancellationToken)
        {
            var membershipType = await _context.MembershipTypes.FindAsync(request.Id);
            return membershipType;
        }
    }

}
