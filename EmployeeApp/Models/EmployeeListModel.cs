using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class EmployeeListModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the {0}")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} length must be between {2} to {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the {0}")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} length must be between {2} to {1}")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter the {0}")]
        [EmailAddress]
        public string Email { get; set; }

        public string Department { get; set; }

        public string? ImageFileName { get; set; }
    }
}
