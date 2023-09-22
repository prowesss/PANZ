using Microsoft.AspNetCore.Identity;
using PANZAPI.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PANZAPI.Models
{
    public class Member : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public GenderEnum Gender { get; set; }

        [Required(ErrorMessage = "Residency Status is required.")]
        public ResidencyStatusEnum ResidencyStatus { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        public bool WillingToVolunteer { get; set; }

        public string Address { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string CompanyName { get; set; }

        public string JobTitle { get; set; }

        [ForeignKey("PaymentMethodId")]
        public Guid PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public string PaymentReference { get; set; }

        public string PaymentSessionId { get; set; }

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
    }
}
