using System;
using System.ComponentModel.DataAnnotations;

namespace AcademyHall.Models.ViewModels
{
    public class StudentSearchModel
    {
        [Display(Name = "Search Parameter ")]
        [RegularExpression(@"^[\w\s\,\.\'\+\-\/]+$", ErrorMessage = "Invalid characters in the field found!!")]
        public String SearchParameter { get; set; }

        [Display(Name = "Gender ")]
        public string SearchGender { get; set; }

        [Display(Name = "Place of Birth: ")]
        [RegularExpression(@"^[\w\s\,\.\'\+\-\/]+$", ErrorMessage = "Invalid characters in the field found!!")]
        public string PlaceOfBirth { get; set; }
    }
}