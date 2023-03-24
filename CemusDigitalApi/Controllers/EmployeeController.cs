using CemusDigitalApi.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace CemusDigitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpPost]
        [Route("AddEmployee")]

        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            var result = await _employee.SaveData<Employee>(employee);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var result = await _employee.GetEmployeeById(id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetEmployees")]

        public async Task<ActionResult<Employee>> GetEmployees()
        {
            var result = await _employee.GetEmployees();

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            var result = await _employee.UpdateEmployee(id, employee);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("AssignEmployee/{id}")]
        public async Task<ActionResult<Employee>> AssignEmployee(int id, Employee employee)
        {
            var result = await _employee.AssignEmployee(id, employee);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]

        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var result = await _employee.DeleteEmployee(id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
