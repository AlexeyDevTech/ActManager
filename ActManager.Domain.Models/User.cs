using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(256)]
        public string PasswordHash { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string TaxMode { get; set; } = "УСН 6%";

        [MaxLength(256)]
        public string? BankSyncToken { get; set; }

        // Навигационные свойства
        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<Tax> Taxes { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<ContractTemplate> ContractTemplates { get; set; }
        public virtual ICollection<BankTransaction> BankTransactions { get; set; }
    }
}
