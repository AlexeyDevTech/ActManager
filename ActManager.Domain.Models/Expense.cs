using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActManager.Domain.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime ExpenseDate { get; set; }

        [MaxLength(260)]
        public string DocumentPath { get; set; }

        public string OcrText { get; set; }

        // Навигационное свойство
        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }
    }
}
