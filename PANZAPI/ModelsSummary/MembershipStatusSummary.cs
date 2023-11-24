
using PANZAPI.Models;

namespace PANZAPI.ModelsSummary
{
    public class MembershipStatusSummary
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

            public MembershipStatusSummary(MembershipStatus membershipStatus)
            {
                Id = membershipStatus.Id;
               Name = membershipStatus.Name;
            }
    }
}
