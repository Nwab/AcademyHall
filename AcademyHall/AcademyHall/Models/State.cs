using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyHall.Models
{
        [Table("State")]
        public class State
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int StateId { get; set; }

            [Column(TypeName = "nvarchar"), StringLength(140)]
            public string StateName { get; set; }

            [Column(TypeName = "nvarchar"), StringLength(140)]
            public string StateCapital { get; set; }

            public virtual ICollection<LGA> LGAs { get; set; }
        }
    
}