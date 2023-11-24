using PANZAPI.Models;

namespace PANZAPI.Repositories.PaymentMethods
{
    public interface IPaymentMethodsRepository
    {
        Task<IEnumerable<PaymentMethod>> GetPaymentMethods();
        Task<PaymentMethod> GetPaymentMethodsById(Guid id);
        Task<Guid> CreatePaymentMethods(PaymentMethod paymentMethod);
        Task UpdatePaymentMethods(Guid id, PaymentMethod paymentMethod);
        Task DeletePaymentMethods(Guid id);
    }
}
