using System.ComponentModel.DataAnnotations;

namespace PANZAPI.Models.Stripe
{
    public class CreateCheckoutSessionRequest
    {
        [Required]
        public string PriceId { get; set; }

        public int? Quantity { get; set; }

        public Guid MemberId { get; set; }
    }
}