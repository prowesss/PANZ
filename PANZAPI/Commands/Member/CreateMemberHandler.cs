using MediatR;
using PANZAPI.ModelsSummary;
using PANZAPI.Repositories.MemberPaymentStatus;
using PANZAPI.Repositories.Members;
using PANZAPI.Repositories.MembershipStatuses;
using PANZAPI.Repositories.MembershipTypes;

namespace PANZAPI.Commands.Member
{
    public class CreateMemberHandler : IRequestHandler<CreateMember, MemberSummary>
    {
        private readonly IMembersRepository _memberRepo;
        private readonly IMembershipStatusRepository _membershipStatusRepo;
        private readonly IMemberPaymentStatusRepository _memberPaymentRepo;
        private readonly IMembershipTypeRepository _membershipTypeRepo;

        public CreateMemberHandler(
            IMembersRepository memberRepo,
            IMemberPaymentStatusRepository memberPaymentRepo,
            IMembershipStatusRepository membershipStatusRepo, 
            IMembershipTypeRepository membershipTypeRepo)
        {
            _memberRepo = memberRepo;
            _membershipStatusRepo = membershipStatusRepo;
            _memberPaymentRepo = memberPaymentRepo;
            _membershipTypeRepo = membershipTypeRepo;
        }

        public async Task<MemberSummary> Handle(CreateMember request, CancellationToken cancellationToken)
        {
            var membershipStatusList = await _membershipStatusRepo.GetMembershipStatuses();
            var onHoldStatus = membershipStatusList.FirstOrDefault(x => x.Name.Equals("Onhold"));

            var MembershipPaymentStatusList = await _memberPaymentRepo.GetMembershipPaymentStatusList();
            var unPaidStatus = MembershipPaymentStatusList.FirstOrDefault(x => x.Name.Equals("Unpaid"));

            var membershipType = await _membershipTypeRepo.GetMembershipTypeByIdAsync(request.MembershipTypeId);

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
                MembershipStatusId = onHoldStatus.Id,
                MembershipPaymentStatusId = unPaidStatus.Id,
                MembershipTypeId = request.MembershipTypeId,
                MembershipType = membershipType
            };

            await _memberRepo.AddMember(newMember);

            return new MemberSummary(newMember);
        }
    }
}
