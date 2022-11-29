namespace EmployeeApp.Models
{
    public class Department : DepartmentListModel
    {
        public List<Employee>? Employees { get; set; }
    }
}
