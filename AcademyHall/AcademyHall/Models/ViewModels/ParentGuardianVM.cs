using System.ComponentModel.DataAnnotations;

namespace AcademyHall.Models.ViewModels
{
    public class ParentGuardianVM
    {
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}