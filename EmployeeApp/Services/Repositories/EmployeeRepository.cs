using EmployeeApp.CustomModelBinders;
using EmployeeApp.Models;
using EmployeeApp.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Services.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IFileCustomFunctions _fileFunctions;

        public EmployeeRepository(AppDbContext context, IFileCustomFunctions fileFunctions)
        {
            _ctx = context;
            _fileFunctions = fileFunctions;
        }

        public async Task<EmployeeDetailsModel> GetEmployeeByIdAsync(int id)
        {
            return await _ctx.Employees
                            .Select(e => new EmployeeDetailsModel
                            {
                                Id = e.Id,
                                Name = e.Name,
                                Surname = e.Surname,
                                Email = e.Email,
                                Department = e.Department.Name,
                                Description = e.Description,
                                DateOfBirth = e.DateOfBirth,
                                ImageFileName = e.ImageFileName != null ? $"/images/{e.ImageFileName}" : null,
                                PhoneNumber = e.PhoneNumber,
                                Salary = e.Salary
                            }).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<EmployeeListModel>> GetAllEmployeesAsync(EmployeeSearchModel employeeSearchModel)
        {
            var employees = await _ctx.Employees
                                    .Skip((employeeSearchModel.Page - 1) * 30)
                                    .Take(30)
                                    .Where(e =>
                                            (e.Name + e.Surname).Contains(employeeSearchModel.v) &&
                                            (employeeSearchModel.SalaryRange != null ? e.Salary > employeeSearchModel.SalaryRange[0] && e.Salary < employeeSearchModel.SalaryRange[1] : true) &&
                                            (employeeSearchModel.DepartmentList != null ? employeeSearchModel.DepartmentList.Any(d => d == e.Department.Name) : true))
                                    .Select(e => new EmployeeListModel()
                                    {
                                        Id = e.Id,
                                        Name = e.Name,
                                        Surname = e.Surname,
                                        Email = e.Email,
                                        Department = e.Department.Name,
                                        ImageFileName = e.ImageFileName != null ? $"/images/{e.ImageFileName}" : null 
                                    })
                                    .ToListAsync();

            return employees;
        }

        public async Task AddEmployeeAsync(Employee employeeModel)
        {
            await _ctx.Employees.AddAsync(employeeModel);

            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = new Employee() { Id = id };

            _ctx.Employees.Remove(employee);

            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateEmployeePatchAsync(int employeeId, JsonPatchDocument employeeModel)
        {
            var employee = await _ctx.Employees.FindAsync(employeeId);

            if (employee != null)
            {
                employeeModel.ApplyTo(employee);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task UpdateEmployeeImageAsync(int employeeId, IFormFile uploadedFile)
        {
            var employee = await GetEmployeeByIdAsync(employeeId);

            if (employee.ImageFileName != null)
            {
                _fileFunctions.DeleteFile(employee.ImageFileName, "images");
            }

            string uniqueFileName = await _fileFunctions.UploadFileAsync(uploadedFile, "images");

            employee.ImageFileName = uniqueFileName;

            await _ctx.SaveChangesAsync();
        }
    }
}
