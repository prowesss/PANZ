using MediatR;
using PANZAPI.Enum;
using PANZAPI.Repositories.MemberPaymentStatus;
using PANZAPI.Repositories.Members;
using PANZAPI.Repositories.MembershipStatuses;
using PANZAPI.Repositories.PaymentMethods;
using System;

namespace PANZAPI.Commands.Member
{
    public class CreateMemberPaymentHandler : IRequestHandler<CreateMemberPayment>
    {
        private IMembersRepository _memberRepo;
        private IPaymentMethodsRepository _paymentMethodRepo;
        private IMemberPaymentStatusRepository _memberPaymentStatusRepo;
        private IMembershipStatusRepository _membershipStatusRepo;

        public CreateMemberPaymentHandler(
            IPaymentMethodsRepository paymentMethodRepo,
             IMembersRepository memberRepo,
             IMemberPaymentStatusRepository memberPaymentStatusRepo,
            IMembershipStatusRepository membershipStatusRepo)
        {
            _memberRepo = memberRepo;
            _paymentMethodRepo = paymentMethodRepo;
            _memberPaymentStatusRepo = memberPaymentStatusRepo;
            _membershipStatusRepo = membershipStatusRepo;
        }

        public async Task<Unit> Handle(CreateMemberPayment request, CancellationToken cancellationToken)
        {
            var paymentMethods = await _paymentMethodRepo.GetPaymentMethods();
            var paymentMethod = paymentMethods.FirstOrDefault(x => x.Name.Equals(request.PaymentMethodName));

            var existingMember = await _memberRepo.GetMemberById(request.MemberId);

            existingMember.PaymentMethod = paymentMethod;
            existingMember.PaymentMethodId = paymentMethod.Id;

            if (paymentMethod.Name.Equals(PaymentMethodsEnum.Bank.ToString()))
            {
                var referenceNumber = GenerateBankReferenceNumber();
                existingMember.PaymentReference = referenceNumber;
            }
            else if (paymentMethod.Name.Equals(PaymentMethodsEnum.Stripe.ToString()))
            {
                var noOfYears = existingMember.MembershipType.NoOfYears;
                var currentDate = DateTime.Now;
                existingMember.PaymentSessionId = request.PaymentSessionId;
                existingMember.PaymentReference = request.PaymentReference;
                
                existingMember.StartDate = currentDate;
                existingMember.ExpireDate = currentDate.AddYears(noOfYears);

                var membershipStatusList = await _membershipStatusRepo.GetMembershipStatuses();
                var newMembershipStatus = membershipStatusList.FirstOrDefault(x => x.Name.Equals("Active"));
                existingMember.MembershipStatus = newMembershipStatus;

                var paymentStatusList = await _memberPaymentStatusRepo.GetMembershipPaymentStatusList();
                var newPaymentStatus = paymentStatusList.FirstOrDefault(x => x.Name.Equals("Paid"));
                existingMember.MembershipPaymentStatus = newPaymentStatus;
            }
        
            await _memberRepo.UpdateMember(existingMember);

            return Unit.Value;
        }

        static string GenerateBankReferenceNumber()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            string alphanumericReference = new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return alphanumericReference;
        }
    }
}
