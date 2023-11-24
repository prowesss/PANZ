
using PANZAPI.Models;

namespace PANZAPI.Repositories.PaymentMethods
{
    public class PaymentMethodsRepository : IPaymentMethodsRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentMethodsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethods()
        {
            return _context.PaymentMethods.ToList();
        }

        public async Task<PaymentMethod> GetPaymentMethodsById(Guid id)
        {
            return await _context.PaymentMethods.FindAsync(id);
        }

        public async Task<Guid> CreatePaymentMethods(PaymentMethod paymentMethod)
        {
            _context.PaymentMethods.Add(paymentMethod);
            await _context.SaveChangesAsync();
            return paymentMethod.Id;
        }

        public async Task UpdatePaymentMethods(Guid id, PaymentMethod paymentMethod)
        {
            var existingPaymentMethod = await _context.PaymentMethods.FindAsync(id);

            if (existingPaymentMethod != null)
            {
                _context.Entry(existingPaymentMethod).CurrentValues.SetValues(paymentMethod);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePaymentMethods(Guid id)
        {
            var membershipStatus = await _context.PaymentMethods.FindAsync(id);

            if (membershipStatus != null)
            {
                _context.PaymentMethods.Remove(membershipStatus);
                await _context.SaveChangesAsync();
            }
        }
    }
}
