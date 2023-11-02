using MediatR;
using PANZAPI.Repositories.Members;

namespace PANZAPI.Commands.Member
{
    public class UpdateMemberHandler : IRequestHandler<UpdateMember, Unit>
    {
        private readonly IMembersRepository _memberRepo;

        public UpdateMemberHandler(IMembersRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public async Task<Unit> Handle(UpdateMember request, CancellationToken cancellationToken)
        {
            var existingMember = await _memberRepo.GetMemberById(request.Id);

            if (existingMember == null)
            {
                return Unit.Value;
            }

            existingMember.Email = request.Email;
            existingMember.FirstName = request.FirstName;
            existingMember.LastName = request.LastName; 
            existingMember.ImageUrl = request.ImageUrl;
            existingMember.Gender = request.Gender;
            existingMember.ResidencyStatus = request.ResidencyStatus;
            existingMember.Phone = request.Phone;
            existingMember.WillingToVolunteer = request.WillingToVolunteer;
            existingMember.Address = request.Address;
            existingMember.City = request.City;
            existingMember.Suburb = request.Suburb;
            existingMember.JobTitle = request.JobTitle;
            existingMember.CompanyName = request.CompanyName;
            existingMember.PaymentMethodId = request.PaymentMethodId;
            existingMember.PaymentReference = request.PaymentReference;
            existingMember.PaymentSessionId = request.PaymentSessionId;
            existingMember.MembershipPaymentStatusId = request.MembershipPaymentStatusId;
            existingMember.MembershipStatusId = request.MembershipStatusId;
            existingMember.MembershipTypeId = request.MembershipTypeId;
            existingMember.StartDate = request.StartDate;
            existingMember.ExpireDate = request.ExpireDate;

            await _memberRepo.UpdateMember(existingMember);

            return Unit.Value;
        }
    }
}
