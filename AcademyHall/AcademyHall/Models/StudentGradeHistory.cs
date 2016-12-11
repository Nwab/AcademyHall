using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyHall.Models
{
    [Table("StudentGradeHistory")]
    public class StudentGradeHistory
    {
        [Key]
         [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int StudentDetailID { get; set; }
        [ForeignKey("StudentDetailID")]
        public virtual StudentDetail StudentDetailModel { get; set; }
        public int GradeID { get; set; }
        [ForeignKey("GradeID")]
        public virtual Grade GradeModel { get; set; }
        public int StaffDetailID { get; set; }
        [ForeignKey("StaffDetailID")]
        public virtual StaffDetail StaffDetailModel { get; set; }
    }
}