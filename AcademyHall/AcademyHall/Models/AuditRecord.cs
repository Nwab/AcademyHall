using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyHall.Models
{
    [Table("AuditRecord")]
    public class AuditRecord
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AuditRecordId { get; set; }
        public string UserAction { get; set; }

        [Column(TypeName = "nvarchar"), StringLength(140)]
        public string TableName { get; set; }

        public string TableKey { get; set; }

        [Required]
        [Column(TypeName = "nvarchar"), StringLength(140)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        public ICollection<AuditRecordField> AuditRecordFldList { get; set; }
    }
}