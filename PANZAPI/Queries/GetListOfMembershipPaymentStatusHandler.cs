using MediatR;
using PANZAPI.Models;
using PANZAPI.ModelsSummary;
using PANZAPI.Repositories.MemberPaymentStatus;

namespace PANZAPI.Queries
{
    public class GetListOfMembershipPaymentStatusHandler : IRequestHandler<GetListOfMembershipPaymentStatus, IEnumerable<MembershipPaymentStatusSummary>>
    {
        private readonly IMemberPaymentStatusRepository _paymentStatusRepo;

        public GetListOfMembershipPaymentStatusHandler(IMemberPaymentStatusRepository paymentStatusRepo)
        {
            _paymentStatusRepo = paymentStatusRepo;
        }

        public async Task<IEnumerable<MembershipPaymentStatusSummary>> Handle(GetListOfMembershipPaymentStatus request, CancellationToken cancellationToken)
        {
            var PaymentStatus =  await _paymentStatusRepo.GetMembershipPaymentStatusList();

            return PaymentStatus.Select(x => new MembershipPaymentStatusSummary(x));
        }
    }
}
