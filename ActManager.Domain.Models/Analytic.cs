using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActManager.Domain.Models
{
    public class Analytic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [Required]
        [MaxLength(7)]
        public string Period { get; set; }

        [Required]
        public double Income { get; set; }

        [Required]
        public double Expenses { get; set; }

        [Required]
        public double Profit { get; set; }

        [Required]
        public double Profitability { get; set; }

        // Навигационное свойство
        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }
    }
}
