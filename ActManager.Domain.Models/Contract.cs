using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActManager.Domain.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenantName { get; set; }

        [MaxLength(50)]
        public string Room { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string PaymentFrequency { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        [MaxLength(260)]
        public string FilePath { get; set; }

        public double? PenaltyRate { get; set; }
        public double? IndexationRate { get; set; }

        // Навигационные свойства
        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
