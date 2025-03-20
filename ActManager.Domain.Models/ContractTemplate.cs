using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActManager.Domain.Models
{
    public class ContractTemplate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string TemplateName { get; set; }

        [Required]
        public string Content { get; set; }

        // Навигационное свойство
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
