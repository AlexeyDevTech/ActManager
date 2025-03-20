using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActManager.Domain.Models
{
    public class BankTransaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string TransactionId { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public int? LinkedPaymentId { get; set; }

        // Навигационные свойства
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("LinkedPaymentId")]
        public virtual Payment LinkedPayment { get; set; }
    }
}
