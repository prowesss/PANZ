

namespace PANZAPI.Models
{
    public class MembershipPaymentStatus : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
