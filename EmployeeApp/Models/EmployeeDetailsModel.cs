using EmployeeApp.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class EmployeeDetailsModel : EmployeeListModel
    {
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "{0} Length Must Be Between {2} to {1}")]
        public string? Description { get; set; }


        [EmployeePhoneNumberValidation]
        public string? PhoneNumber { get; set; }


        [EmployeeDateOfBirthValidation]
        public string? DateOfBirth { get; set; }


        [Required(ErrorMessage = "Salary is required")]
        [Range(200000, 1500000, ErrorMessage = "{0} must be between {2} to {1}")]
        public int Salary { get; set; }
    }
}
