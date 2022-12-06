using EmployeeApp.Models;

namespace EmployeeApp.CustomModelBinders
{
    public class EmployeeSearchModel
    {
        public string v { get; set; } = "";

        public int[]? SalaryRange { get; set; } = null;

        public string[]? DepartmentList { get; set; } = null;

        public int Page { get; set; } = 1;
    }
}
