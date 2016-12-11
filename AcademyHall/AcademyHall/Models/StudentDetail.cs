using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyHall.Models
{
    [Table("StudentDetail")]
    public class StudentDetail
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string StudentRegistrationNo{ get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PlaceOfBirth { get; set; }
        public Nullable<int> LGAOfOriginID { get; set; }
        [ForeignKey("LGAOfOriginID")]
        public virtual LGA LGAOfOrigin { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateRegistered { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
         [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string FatherFullName { get; set; }
        public string MotherFullName { get; set; }
        public string FatherMobilePhone { get; set; }
        public string MotherMobilePhone { get; set; }
        public string FatherProfession { get; set; }
        public string MotherProfession { get; set; }
        public string FatherPlaceOfWork { get; set; }
        public string MotherPlaceOfWork { get; set; }
        [DataType(DataType.EmailAddress)]
        public string FatherEmailAddress { get; set; }
         [DataType(DataType.EmailAddress)]
        public string MotherEmailAddress { get; set; }
       
        [Required]
        public string Observations { get; set; }
        public int AcademyUserId { get; set; }
        [ForeignKey("AcademyUserId")]
        public virtual AcademyUser AcademyStudent { get; set; }
    }
}