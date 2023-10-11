using MediatR;
using PANZAPI.Repositories.MemberPaymentStatus;

namespace PANZAPI.Commands.MembershipPaymentStatus
{
    public class DeleteMembershipPaymentStatusHandler : IRequestHandler<DeleteMembershipPaymentStatus, Unit>
    {
        private readonly IMemberPaymentStatusRepository _paymentStatusRepo;

        public DeleteMembershipPaymentStatusHandler(IMemberPaymentStatusRepository paymentStatusRepo)
        {
            _paymentStatusRepo = paymentStatusRepo;
        }

        public async Task<Unit> Handle(DeleteMembershipPaymentStatus request, CancellationToken cancellationToken)
        {
            var existingStatus = await _paymentStatusRepo.GetMembershipPaymentStatusById(request.Id);

            if (existingStatus == null)
            {
                return Unit.Value;
            }
            existingStatus.IsActive = false;

            await _paymentStatusRepo.UpdateMembershipPaymentStatus(existingStatus);

            return Unit.Value;
        }
    }
}
