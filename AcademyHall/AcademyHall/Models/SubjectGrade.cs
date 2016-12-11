using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyHall.Models
{
    [Table("SubjectGrade")]
    public class SubjectGrade
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject SubjectModel { get; set; }
        public int GradeID { get; set; }
        [ForeignKey("GradeID")]
        public virtual Grade GradeModel { get; set; }

    }
}