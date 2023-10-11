using MediatR;
using PANZAPI.Models;
using PANZAPI.Repositories.MembershipActivity;

namespace PANZAPI.Commands.MembershipActivity
{
    public class AddMembershipActivityHandler : IRequestHandler<AddMembershipActivity, Unit>
    {
        private readonly IMembershipActivityRepository _activityRepo;

        public AddMembershipActivityHandler(IMembershipActivityRepository activityRepo)
        {
            _activityRepo = activityRepo;
        }

        public async Task<Unit> Handle(AddMembershipActivity request, CancellationToken cancellationToken)
        {
            
                var log = new MembershipActivityLog(
                    request.MemberId,
                    request.PaymentMethodId,
                    request.MembershipStatusId,
                    request.MembershipPaymentStatusId,
                    request.MembershipTypeId,
                    request.StartDate,
                    request.ExpireDate
                );

                await _activityRepo.AddMembershipActivity(log);

                return Unit.Value;
           
        }
    }
}
