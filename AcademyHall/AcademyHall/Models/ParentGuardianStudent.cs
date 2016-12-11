using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyHall.Models
{
     [Table("ParentGuardianStudent")]
    public class ParentGuardianStudent
    {
        [Key]
         [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int StudentDetailID { get; set; }
        [ForeignKey("StudentDetailID")]
        public virtual StudentDetail StudentDetailModel { get; set; }
        public int ParentGuardianID { get; set; }
        [ForeignKey("ParentGuardianID")]
        public virtual ParentGuardian ParentGuardianModel { get; set; }

    }
}