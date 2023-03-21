using CemusDigitalApi.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace CemusDigitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _department;

        public DepartmentController(IDepartment department)
        {
            _department = department;
        }

        [HttpPost]
        [Route("AddDepartment")]

        public async Task<ActionResult<Department>> SaveData(Department department)
        {
            var result = await _department.SaveData<Department>(department);

            if(result == null)
            {
               return BadRequest();
            }
            return Ok(result);
        }


        [HttpGet]
        [Route("GetDepartment")]

        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            var result = await _department.GetDepartmentById(id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetDepartments")]

        public async Task<ActionResult<Department>> GetDepartments()
        {
            var result = await _department.GetDepartments();

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateDepartment/{id}")]
        public async Task<ActionResult<Department>> UpdateDepartment(int id, Department department)
        {
           var result = await _department.UpdateDepartment(id, department);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteDepartment/{id}")]

        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {
            var result = await _department.DeleteDepartment(id);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

    }
}
