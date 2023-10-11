using MediatR;
using PANZAPI.Models;
using PANZAPI.Repositories.MembershipActivity;

namespace PANZAPI.Commands.MembershipActivity
{
    public class UpdateMembershipActivityHandler : IRequestHandler<UpdateMembershipActivity, Unit>
    {

        private readonly IMembershipActivityRepository _activityRepo;

        public UpdateMembershipActivityHandler(IMembershipActivityRepository activityRepo)
        {
            _activityRepo = activityRepo;
        }

        public async Task<Unit> Handle(UpdateMembershipActivity request, CancellationToken cancellationToken)
        {
            var activity = await _activityRepo.Find(request.Id);
            if (activity == null)
            {
            }

            activity.MemberId = request.MemberId;
            activity.PaymentMethodId = request.PaymentMethodId;
            activity.MembershipStatusId = request.MembershipStatusId;
            activity.MembershipPaymentStatusId = request.MembershipPaymentStatusId;
            activity.MembershipTypeId = request.MembershipTypeId;
            activity.StartDate = request.StartDate;
            activity.ExpireDate = request.ExpireDate;
            await _activityRepo.Update(activity);
            return Unit.Value;
        }
    }
}
