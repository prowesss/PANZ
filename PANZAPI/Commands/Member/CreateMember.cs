using MediatR;
using PANZAPI.Enum;
using PANZAPI.ModelsSummary;

namespace PANZAPI.Commands.Member
{
    public class CreateMember : IRequest<MemberSummary>
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Gender { get; set; }
        public string ResidencyStatus { get; set; }
        public string Phone { get; set; }
        public bool WillingToVolunteer { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public Guid MembershipTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
