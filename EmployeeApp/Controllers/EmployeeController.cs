using EmployeeApp.CustomModelBinders;
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

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployeeList([FromQuery] [ModelBinder(typeof(EmployeeSearchBinder))] EmployeeSearchModel employeeSearchModel)
        {
            var employeeList = await _employeeRepository.GetAllEmployeesAsync(employeeSearchModel);

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
