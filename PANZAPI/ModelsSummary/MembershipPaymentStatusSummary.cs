
using PANZAPI.Models;

namespace PANZAPI.ModelsSummary
{
    public class MembershipPaymentStatusSummary
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

            public MembershipPaymentStatusSummary(MembershipPaymentStatus membershipPaymentStatus)
            {
                Id = membershipPaymentStatus.Id;
               Name = membershipPaymentStatus.Name;
            }
    }
}
