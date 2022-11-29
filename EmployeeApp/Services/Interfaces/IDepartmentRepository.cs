using Microsoft.AspNetCore.JsonPatch;
using EmployeeApp.Models;

namespace EmployeeApp.Services.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentListModel>> GetAllDepartmentsAsync();
        Task AddDepartmentAsync(Department departmentModel);
        Task UpdateDepartmentPatchAsync(int departmentId, JsonPatchDocument departmentModel);
        Task DeleteDepartmentAsync(int id);
    }
}
