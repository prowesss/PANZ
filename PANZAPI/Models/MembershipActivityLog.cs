using System.ComponentModel.DataAnnotations.Schema;

namespace PANZAPI.Models
{
    public class MembershipActivityLog
    {
       

        public Guid Id { get; set; }

        [ForeignKey("MemberId")]
        public Guid MemberId { get; set; }
        public Member Member { get; set; }

        [ForeignKey("PaymentMethodId")]
        public Guid PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        [ForeignKey("MembershipStatusId")]
        public Guid MembershipStatusId { get; set; }
        public MembershipStatus MembershipStatus { get; set; }

        [ForeignKey("MembershipPaymentStatusId")]
        public Guid MembershipPaymentStatusId { get; set; }
        public MembershipPaymentStatus MembershipPaymentStatus { get; set; }

        [ForeignKey("MembershipTypeId")]
        public Guid MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public MembershipActivityLog(
            Guid memberId,
            Guid paymentMethodId,
            Guid membershipStatusId,
            Guid membershipPaymentStatusId,
            Guid membershipTypeId,
            DateTime startDate,
            DateTime expireDate)
        {
            MemberId = memberId;
            PaymentMethodId = paymentMethodId;
            MembershipStatusId = membershipStatusId;
            MembershipPaymentStatusId = membershipPaymentStatusId;
            MembershipTypeId = membershipTypeId;
            StartDate = startDate;
            ExpireDate = expireDate;

        }

    }
}
