using MediatR;
using PANZAPI.Repositories.MemberPaymentStatus;

namespace PANZAPI.Commands.MembershipPaymentStatus
{
    public class CreateMembershipPaymentStatusHandler : IRequestHandler<CreateMembershipPaymentStatus, Guid>
    {
        private readonly IMemberPaymentStatusRepository _paymentStatusRepo;

        public CreateMembershipPaymentStatusHandler(IMemberPaymentStatusRepository paymentStatusRepo)
        {
            _paymentStatusRepo = paymentStatusRepo;
        }

        public async Task<Guid> Handle(CreateMembershipPaymentStatus request, CancellationToken cancellationToken)
        {
            var newStatus = new PANZAPI.Models.MembershipPaymentStatus
            {
                Name = request.Name,
                Description = request.Description
            };

            await _paymentStatusRepo.AddMembershipPaymentStatus(newStatus);

            return newStatus.Id;
        }
    }
}
