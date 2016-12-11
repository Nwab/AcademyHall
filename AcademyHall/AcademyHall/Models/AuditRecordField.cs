using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyHall.Models
{
    [Table("AuditRecordField")]
    public class AuditRecordField
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AuditFldId { get; set; }

        public int? AuditRecordId { get; set; }
        [ForeignKey("AuditRecordId")]
        public virtual AuditRecord AuditRecord { get; set; }
        [Column(TypeName = "nvarchar")]
        public string MemberName { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

    }
}