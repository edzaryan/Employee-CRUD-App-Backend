using EmployeeApp.CustomModelBinders;
using EmployeeApp.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace EmployeeApp.Services.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeListModel>> GetAllEmployeesAsync(EmployeeSearchModel employeeSearchModel);

        Task<EmployeeDetailsModel> GetEmployeeByIdAsync(int id);

        Task AddEmployeeAsync(Employee departmentModel);

        Task UpdateEmployeePatchAsync(int employeeId, JsonPatchDocument employeeModel);

        Task UpdateEmployeeImageAsync(int employeeId, IFormFile uploadedFile);

        Task DeleteEmployeeAsync(int id);
    }
}
