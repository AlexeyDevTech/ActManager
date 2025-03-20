using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActManager.Domain.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        public int? RelatedEntityId { get; set; }

        [Required]
        public bool IsRead { get; set; } = false;

        // Навигационное свойство
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
