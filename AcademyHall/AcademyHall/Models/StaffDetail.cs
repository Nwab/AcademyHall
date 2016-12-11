using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AcademyHall.Models
{
    [Table("StaffDetail")]
    public class StaffDetail
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string StaffID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PlaceOfBirth { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string HomeAdddress { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.EmailAddress)]
        public string StaffEmail { get; set; }
        public string Telephone { get; set; }
        [Required]
        public string MobilePhone { get; set; }
        [Required]
        public DateTime DateOfHire { get; set; }
        public int AcademyUserId { get; set; }
        [ForeignKey("AcademyUserId")]
        public virtual AcademyUser AcademyStaffUser { get; set; }

    }
}