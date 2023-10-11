using MediatR;
using PANZAPI.Models;
using PANZAPI.Repositories.MemberPaymentStatus;

namespace PANZAPI.Queries
{
    public class GetMembershipPaymentStatusByIdHandler : IRequestHandler<GetMembershipPaymentStatusById, MembershipPaymentStatus>
    {
        private readonly IMemberPaymentStatusRepository _paymentStatusRepo;

        public GetMembershipPaymentStatusByIdHandler(IMemberPaymentStatusRepository paymentStatusRepo)
        {
            _paymentStatusRepo = paymentStatusRepo;
        }

        public async Task<MembershipPaymentStatus> Handle(GetMembershipPaymentStatusById request, CancellationToken cancellationToken)
        {
            return await _paymentStatusRepo.GetMembershipPaymentStatusById(request.Id);

        }
    }
}
