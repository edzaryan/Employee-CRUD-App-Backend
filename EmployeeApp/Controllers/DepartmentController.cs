using EmployeeApp.Models;
using EmployeeApp.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EmployeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository) => _departmentRepository = departmentRepository;


        [HttpGet("")]
        public async Task<IActionResult> GetDepartmentList()
        {
            var departmentList = await _departmentRepository.GetAllDepartmentsAsync();
            
            return Ok(departmentList);
        }


        [HttpPost("")]
        public async Task<IActionResult> CreateDepartment([FromBody] Department department)
        {
            await _departmentRepository.AddDepartmentAsync(department);

            return Ok();
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateDepartmentPatch([FromRoute] int id, [FromBody] JsonPatchDocument department)
        {   
            await _departmentRepository.UpdateDepartmentPatchAsync(id, department);

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            await _departmentRepository.DeleteDepartmentAsync(id);

            return Ok();
        }

        
    }
}
 