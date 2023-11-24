using PANZAPI.Models;

namespace PANZAPI.ModelsSummary
{
    public class MemberSummary
    {
        public Guid Id { get; set; }

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

        public string PaymentMethodUsed { get; set; }

        public string PaymentReference { get; set; }

        public string PaymentSessionId { get; set; }

        public string MembershipStatus { get; set; }

        public string MembershipPaymentStatus { get; set; }

        public string MembershipType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public MemberSummary(Member member)
        {
            Id = member.Id;
            UserId = member.UserId;
            Email = member.Email;
            FirstName = member.FirstName;
            LastName = member.LastName;
            ImageUrl = member.ImageUrl;
            Gender = member.Gender;
            ResidencyStatus = member.ResidencyStatus;
            Phone = member.Phone;
            WillingToVolunteer = member.WillingToVolunteer;
            Address = member.Address;
            Suburb = member.Suburb;
            City = member.City;
            CompanyName = member.CompanyName;
            JobTitle = member.JobTitle;
            PaymentMethodUsed = member.PaymentMethod?.Name ?? null;
            PaymentReference = member.PaymentReference ?? null;
            PaymentSessionId = member.PaymentSessionId ?? null;
            MembershipStatus = member.MembershipStatus.Name;
            MembershipPaymentStatus = member.MembershipPaymentStatus.Name;
            MembershipType = member.MembershipType.Name;
            StartDate = member.StartDate;
            ExpireDate = member.ExpireDate;
        }
    }

    
}
