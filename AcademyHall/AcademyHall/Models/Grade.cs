using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyHall.Models
{
    [Table("Grade")]
    public class Grade
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Observation { get; set; }
        public int GradeLevelID { get; set; }
        [ForeignKey("GradeLevelID")]
        public virtual GradeLevel GradeLevelModel { get; set; }
    }
}