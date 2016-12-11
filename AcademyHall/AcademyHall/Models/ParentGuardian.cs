using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyHall.Models
{
    [Table("ParentGuradian")]
    public class ParentGuardian
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Relationship { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactAddress { get; set; }
        public string HouseAddress { get; set; }
        public int AcademyUserId { get; set; }
        [ForeignKey("AcademyUserId")]
        public  AcademyUser AcademyGuardianUser { get; set; }

    }
}