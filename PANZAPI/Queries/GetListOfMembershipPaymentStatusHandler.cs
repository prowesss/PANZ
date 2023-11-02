using MediatR;
using PANZAPI.Models;
using PANZAPI.Repositories.MemberPaymentStatus;

namespace PANZAPI.Queries
{
    public class GetListOfMembershipPaymentStatusHandler : IRequestHandler<GetListOfMembershipPaymentStatus, IEnumerable<MembershipPaymentStatus>>
    {
        private readonly IMemberPaymentStatusRepository _paymentStatusRepo;

        public GetListOfMembershipPaymentStatusHandler(IMemberPaymentStatusRepository paymentStatusRepo)
        {
            _paymentStatusRepo = paymentStatusRepo;
        }

        public async Task<IEnumerable<MembershipPaymentStatus>> Handle(GetListOfMembershipPaymentStatus request, CancellationToken cancellationToken)
        {
            return await _paymentStatusRepo.GetMembershipPaymentStatusList();
        }
    }
}
