using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class Employee : EmployeeDetailsModel
    {
        public int? DepartmentId { get; set; }

        public new Department? Department { get; set; }
    }
}
