using MediatR;
using PANZAPI.Models;

namespace PANZAPI.Queries
{
    public class GetListOfPayments : IRequest<List<PaymentMethod>>
    {
    }
}
