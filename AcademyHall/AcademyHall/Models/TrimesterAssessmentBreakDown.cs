using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyHall.Models
{
    [Table("TrimesterAssessmentBreakDown")]
    public class TrimesterAssessmentBreakDown
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int AssessmentScore { get; set; }
        public string AssessmentDescription { get; set; }
         [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy hh:mm:ss}",ApplyFormatInEditMode=true)]
        public DateTime DateAssessmentCreated { get; set; }
        public int AssessmentTypeID { get; set; }
        [ForeignKey("AssessmentTypeID")]
        public virtual AssessmentType AssessmentTypeModel { get; set; }
        public int TrimesterNameID { get; set; }
        [ForeignKey("AssessmentTypeID")]
        public virtual TrimesterName TrimesterNameModel { get; set; }

    }
}