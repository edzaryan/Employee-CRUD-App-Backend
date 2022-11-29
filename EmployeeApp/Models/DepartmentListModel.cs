using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class DepartmentListModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Department Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Department {0} length must be from {2} to {1} characters")]
        public string Name { get; set; }
    }
}
