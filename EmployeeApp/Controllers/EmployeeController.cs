using EmployeeApp.Models;
using EmployeeApp.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IFileCustomFunctions _fileFunctions;

        public EmployeeController(IEmployeeRepository employeeRepository, IFileCustomFunctions fileFunctions)
        {
            _employeeRepository = employeeRepository;
            _fileFunctions = fileFunctions;
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployeeList()
        {
            var employeeList = await _employeeRepository.GetAllEmployeesAsync();

            return Ok(employeeList);
        }


        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int employeeId)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);

            return Ok(employee);
        }


        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);

            return Ok();
        }


        [HttpPatch("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeePatch([FromRoute] int employeeId, [FromBody] JsonPatchDocument employee)
        {
            await _employeeRepository.UpdateEmployeePatchAsync(employeeId, employee);

            return Ok();
        }


        [HttpPut("{employeeId}/UploadFile")]
        public async Task<IActionResult> UploadEmployeeImage([FromRoute] int employeeId, [FromForm] IFormFile uploadedFile)
        {
            await _employeeRepository.UpdateEmployeeImageAsync(employeeId, uploadedFile);            
            
            return Ok();
        }


        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int employeeId) 
        {
            await _employeeRepository.DeleteEmployeeAsync(employeeId);

            return Ok();
        }

    }
}
