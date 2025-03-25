using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActManager.Domain.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; } //возможно рудимент

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        public double? Area { get; set; }

        [MaxLength(260)]
        public string PhotoPath { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        // Навигационные свойства
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("BuildingId")]
        public virtual Building? Building { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Analytic> Analytics { get; set; }
    }
}
