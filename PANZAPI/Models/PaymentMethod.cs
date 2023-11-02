using System.ComponentModel.DataAnnotations;

namespace PANZAPI.Models
{
    public class PaymentMethod : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

    }

}