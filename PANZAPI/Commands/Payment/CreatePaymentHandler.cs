using MediatR;
using Microsoft.AspNetCore.Mvc;
using PANZAPI.Models;

namespace PANZAPI.Commands.Payment
{
    public class CreatePaymentHandler : IRequestHandler<CreatePayment, IActionResult>
    {
        private readonly ApplicationDbContext _context;

        public CreatePaymentHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Handle(CreatePayment request, CancellationToken cancellationToken)
        {

            _context.PaymentMethods.Add(request.Payment);
            await _context.SaveChangesAsync();
            return new CreatedAtActionResult("GetPayment", null, new { id = request.Payment.Id }, request.Payment);
        }
    }

}
