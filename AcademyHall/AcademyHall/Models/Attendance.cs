using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyHall.Models
{
    [Table("Attendance")]
    public class Attendance
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public bool Attended { get; set; }
        public DateTime DateAttended { get; set; }
        public int StudentDetailId { get; set; }
        [ForeignKey("StudentDetailId")]
        public virtual StudentDetail StudentDetailModel { get; set; }
    }
}