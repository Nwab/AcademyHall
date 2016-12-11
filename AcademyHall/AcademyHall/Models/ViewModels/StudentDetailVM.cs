﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AcademyHall.Models.ViewModels
{
    public class StudentDetailVM
    {
        public int StudentDetailID { get; set; }
        //Generated by the application
        [RegularExpression(@"^[\w\s\,\.\'\+\-\/]+$", ErrorMessage = "Invalid characters in the field found!!")]
        public string StudentRegistrationNo { get; set; }
        [Required]
        [Display(Name = "First Name:")]
        [RegularExpression(@"^[\w\s\,\.\'\+\-\/]+$", ErrorMessage = "Invalid characters in the FirstName field found!!")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name:")]
        [RegularExpression(@"^[\w\s\,\.\'\+\-\/]+$", ErrorMessage = "Invalid characters in the MiddleName field found!!")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name:")]
        [RegularExpression(@"^[\w\s\,\.\'\+\-\/]+$", ErrorMessage = "Invalid characters in the LastName field found!!")]
        public string LastName { get; set; }
        [Display(Name = "Place of Birth:")]
        [RegularExpression(@"^[\w\s\,\.\'\+\-\/]+$", ErrorMessage = "Invalid characters in the PlaceOfBirth field found!!")]
        public string PlaceOfBirth { get; set; }


        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Date of Birth:")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateRegistered { get; set; }
        [Required]
        [Display(Name = "Gender:")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Home Address:")]
        public string Address { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Home Telephone:")]
        [RegularExpression(@"([-()_.+ ]*\d[-()_.+ ]*){9,14}$", ErrorMessage = "Entered phone format is not valid.")]
        public string Telephone { get; set; }

        [Display(Name = "Mobile Phone:")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"([-()_.+ ]*\d[-()_.+ ]*){9,14}$", ErrorMessage = "Entered phone format is not valid.")]
        public string MobilePhone { get; set; }
        public int ParentGuardianId { get; set; }
    }

    public class StudentFamilyDetailVM
    {
        [Display(Name = "Father Full Name:")]
        [RegularExpression(@"^[\w\s\,\.\'\+\-\/]+$", ErrorMessage = "Invalid characters in the FirstName field found!!")]
        public string FatherFullName { get; set; }
        [Display(Name = "Mother Full Name:")]
        [RegularExpression(@"^[\w\s\,\.\'\+\-\/]+$", ErrorMessage = "Invalid characters in the FirstName field found!!")]
        public string MotherFullName { get; set; }

        [Display(Name = "Father Mobile Phone:")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"([-()_.+ ]*\d[-()_.+ ]*){9,14}$", ErrorMessage = "Entered phone format is not valid.")]
        public string FatherMobilePhone { get; set; }

        [Display(Name = "Mother Mobile Phone:")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"([-()_.+ ]*\d[-()_.+ ]*){9,14}$", ErrorMessage = "Entered phone format is not valid.")]
        public string MotherMobilePhone { get; set; }
        [Display(Name = "Father's Profession:")]
        public string FatherProfession { get; set; }
        [Display(Name = "Mother's Profession:")]
        public string MotherProfession { get; set; }
        [Display(Name = "Father's Place of Work:")]
        public string FatherPlaceOfWork { get; set; }
        [Display(Name = "Mother's Place of Work:")]
        public string MotherPlaceOfWork { get; set; }
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "You must provide a valid email address.")]
        public string FatherEmailAddress { get; set; }
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "You must provide a valid email address.")]
        public string MotherEmailAddress { get; set; }
        [Required]
        [Display(Name = "Any Observation:")]
        public string Observations { get; set; }

    }

    public class CombinedStudentDetailVM
    {
        public StudentDetailVM studentDetailVM { get; set; }
        public StudentFamilyDetailVM familyDetailVM { get; set; }
    }
}