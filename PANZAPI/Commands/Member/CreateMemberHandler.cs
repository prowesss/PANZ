using MediatR;
using PANZAPI.Repositories.Members;

namespace PANZAPI.Commands.Member
{
    public class CreateMemberHandler : IRequestHandler<CreateMember, Guid>
    {
        private readonly IMembersRepository _memberRepo;

        public CreateMemberHandler(IMembersRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public async Task<Guid> Handle(CreateMember request, CancellationToken cancellationToken)
        {
             var newMember = new PANZAPI.Models.Member
        {
            UserId = request.UserId,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            ImageUrl = request.ImageUrl,
            Gender = request.Gender,
            ResidencyStatus = request.ResidencyStatus,
            Phone = request.Phone,
            WillingToVolunteer = request.WillingToVolunteer,
            Address = request.Address,
            Suburb = request.Suburb,
            City = request.City,
            CompanyName = request.CompanyName,
            JobTitle = request.JobTitle,
            PaymentMethodId = request.PaymentMethodId,
            PaymentReference = request.PaymentReference,
            PaymentSessionId = request.PaymentSessionId,
            MembershipStatusId = request.MembershipStatusId,
            MembershipPaymentStatusId = request.MembershipPaymentStatusId,
            MembershipTypeId = request.MembershipTypeId,
            StartDate = request.StartDate,
            ExpireDate = request.ExpireDate
        };

        await _memberRepo.AddMember(newMember);

        return newMember.Id;
        }
    }
}
