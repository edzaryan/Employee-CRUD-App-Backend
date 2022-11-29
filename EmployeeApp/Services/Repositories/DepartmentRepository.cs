using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using EmployeeApp.Services.Interfaces;

namespace EmployeeApp.Services.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _ctx;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            _ctx = appDbContext;
        }

        public async Task<List<DepartmentListModel>> GetAllDepartmentsAsync()
        {
            var departments = await _ctx.Departments.Select(d => new DepartmentListModel()
            {
                Id = d.Id,
                Name = d.Name,
            }).ToListAsync();

            return departments;
        }

        public async Task AddDepartmentAsync(Department departmentModel)
        {
            var department = new Department { Name = departmentModel.Name };

            _ctx.Departments.Add(department);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateDepartmentPatchAsync(int departmentId, JsonPatchDocument departmentModel)
        {
            var department = await _ctx.Departments.FindAsync(departmentId);

            if (department != null)
            {
                departmentModel.ApplyTo(department);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = new Department() { Id = id };

            _ctx.Departments.Remove(department);

            await _ctx.SaveChangesAsync();
        }
    }
}
