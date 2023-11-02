using MediatR;
using PANZAPI.Repositories.MemberPaymentStatus;

namespace PANZAPI.Commands.MembershipPaymentStatus
{
    public class UpdateMembershipPaymentStatusHandler : IRequestHandler<UpdateMembershipPaymentStatus, Unit>
    {
        private readonly IMemberPaymentStatusRepository _paymentStatusRepo;

        public UpdateMembershipPaymentStatusHandler(IMemberPaymentStatusRepository paymentStatusRepo)
        {
            _paymentStatusRepo = paymentStatusRepo;
        }


        public async Task<Unit> Handle(UpdateMembershipPaymentStatus request, CancellationToken cancellationToken)
        {
            var existingStatus = await _paymentStatusRepo.GetMembershipPaymentStatusById(request.Id);

            if (existingStatus == null)
            {
                // Handle not found error, perhaps return a NotFound result
                return Unit.Value;
            }

            // Update properties
            existingStatus.Name = request.Name;
            existingStatus.Description = request.Description;

            await _paymentStatusRepo.UpdateMembershipPaymentStatus(existingStatus);

            return Unit.Value;
        }
    }
}
