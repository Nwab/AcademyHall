
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AcademyHall.Models
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
         [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string SubjAbbreviation { get; set; }
        public int SubjectAreaID { get; set; }
        [ForeignKey("SubjectAreaID")]
        public virtual SubjectArea SubjectAreaModel { get; set; }

    }
}