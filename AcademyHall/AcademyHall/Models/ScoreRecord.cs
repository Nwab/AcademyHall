using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyHall.Models
{
    [Table("ScoreRecord")]
    public class ScoreRecord
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int StudentDetailID { get; set; }
        [ForeignKey("StudentDetailID")]
        public virtual StudentDetail StudentDetModel { get; set; }
        public int SubjectID { get; set; }
        [ForeignKey("SubjectID")]
        public virtual Subject SubjectModel { get; set; }
        public string FinalCumulativeGrade { get; set; }
        public int TrimesterAssessmentBreakDownID { get; set; }
        [ForeignKey("TrimesterAssessmentBreakDownID")]
        public virtual TrimesterAssessmentBreakDown TrimesterAssessmentBreakDownModel { get; set; }
        
        
        
    }
}