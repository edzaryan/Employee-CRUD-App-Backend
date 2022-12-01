using EmployeeApp.Models;

namespace EmployeeApp.CustomModelBinders
{
    public class EmployeeSearchModel
    {
        public string v { get; set; } = "";

        public int[] SalaryRange { get; set; } = { 100000, 15000000 };

        public string[] DepartmentList { get; set; } = { "Java" };

        public int Page { get; set; } = 1;
    }
}
