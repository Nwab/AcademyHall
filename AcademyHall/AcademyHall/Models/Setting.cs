using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyHall.Models
{
    [Table("Setting")]
    public class Setting
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SettingId { get; set; }
        [Required]
         [RegularExpression(@"^[\w\s\,\.\'\+\-\/]+$", ErrorMessage = "Invalid characters in the field found!!")]
        public string SettingKey { get; set; }
        [Required]
        [RegularExpression(@"^[\w\s\,\.\'\+\<\>\-\/]+$", ErrorMessage = "Invalid characters in the field found!!")]
        public string SettingValue { get; set; }
    }
}