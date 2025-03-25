using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActManager.Domain.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        [Required]
        [MaxLength(20)]
        public string Source { get; set; } = "manual";

        // Навигационное свойство
        [ForeignKey("ContractId")]
        public virtual Contract Contract { get; set; }
        public virtual BankTransaction BankTransaction { get; set; }
    }
}
