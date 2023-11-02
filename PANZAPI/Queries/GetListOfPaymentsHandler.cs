using MediatR;
using Microsoft.EntityFrameworkCore;
using PANZAPI.Models;

namespace PANZAPI.Queries
{
    public class GetListOfPaymentsHandler : IRequestHandler<GetListOfPayments, List<PaymentMethod>>
    {
        private readonly ApplicationDbContext _context;

        public GetListOfPaymentsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PaymentMethod>> Handle(GetListOfPayments request, CancellationToken cancellationToken)
        {
            var payments = await _context.PaymentMethods.ToListAsync();
            return payments;
        }
    }

}
