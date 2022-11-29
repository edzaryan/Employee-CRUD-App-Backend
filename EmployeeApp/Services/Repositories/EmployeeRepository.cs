using EmployeeApp.Models;
using EmployeeApp.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
            var employee = await _ctx.Employees.Select(e => new EmployeeDetailsModel()
            {
                Id = e.Id,
                Name = e.Name,
                Surname = e.Surname,
                Email = e.Email,
                Department = e.Department.Name
            }).FirstOrDefaultAsync();

            return employee;
        }

        public async Task<List<EmployeeListModel>> GetAllEmployeesAsync()
        {
            var employees = await _ctx.Employees.Select(e => new EmployeeListModel()
            {
                Id = e.Id,
                Name = e.Name,
                Surname = e.Surname,
                Email = e.Email,
                Department = e.Department.Name,
                ImageFileName = $"/images/{e.ImageFileName}"
            }).ToListAsync();

            return employees;
        }

        public async Task AddEmployeeAsync(Employee employeeModel)
        {
            var employee = new Employee
            {
                Name = employeeModel.Name,
                Surname = employeeModel.Surname,
                Email = employeeModel.Email,
                DepartmentId = employeeModel.DepartmentId,
                DateOfBirth = employeeModel.DateOfBirth,
                Description = employeeModel.Description,
                PhoneNumber = employeeModel.PhoneNumber,
                Salary = employeeModel.Salary,
            };

            await _ctx.Employees.AddAsync(employee);
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
