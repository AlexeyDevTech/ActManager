using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActManager.Domain.Models
{
    public class Tax
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(7)]
        public string Period { get; set; } // Например, "2025-03"

        [Required]
        public double Income { get; set; }

        [Required]
        public double Expenses { get; set; }

        [Required]
        public double TaxAmount { get; set; }

        public double? MinTaxAmount { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        // Навигационное свойство
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
