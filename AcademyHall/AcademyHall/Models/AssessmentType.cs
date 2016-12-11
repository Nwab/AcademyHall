using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyHall.Models
{
    /// <summary>
    /// Continuous Assessment, Exams
    /// </summary>
     [Table("AssessmentType")]
    public class AssessmentType
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}