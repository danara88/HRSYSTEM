using AutoMapper;
using HRSYSTEM.application;
using HRSYSTEM.domain;
using HRSYSTEM.persistance.Repositories.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace HRSYSTEM.api.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// This action creates a new employee
        /// </summary>
        /// <param name="employeeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/employees")]
        public async Task<ActionResult> CreateEmployee([FromBody] CreateEmployeeCommand model)
        {
            if (!ModelState.IsValid) return BadRequest();
            CreateEmployeeDTO response = await _mediator.Send(model);
            return Ok(response);
        }
           
        /// <summary>
        /// This action will return all the employees of the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/employees")]
        public async Task<ActionResult<IEnumerable<GetEmployeesDTO>>> GetAllEmployees()
        {
            if (!ModelState.IsValid) return BadRequest();
            IEnumerable<GetEmployeesDTO> employeesDTO = await _mediator.Send(new GetEmployeesQuery());
            return Ok(employeesDTO);

        }

        /// <summary>
        /// This action will return employees depending of their status
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/employeesByStatus")]
        public async Task<ActionResult<IEnumerable<GetEmployeesDTO>>> GetEmployeesByStatus([FromQuery] int Status = 1)
        {
            if (!ModelState.IsValid) return BadRequest();
            IEnumerable<GetEmployeesDTO> employeesDTO = await _mediator.Send(new GetEmployeesByStatusQuery(Status));
            return Ok(employeesDTO);

        }

        /// <summary>
        /// This action will return one employee
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/employee/{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            EmployeeDTO employeeDTO = await _mediator.Send(new GetEmployeeQuery(id));
            return Ok(employeeDTO);
        }

        /// <summary>
        /// This action will update an employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/employees/{id}")]
        public async Task<ActionResult> UpdateEmployeeById(int id, [FromBody] UpdateEmployeeCommand model)
        {
            if (!ModelState.IsValid) return BadRequest();
            EmployeeDTO employeeDTO = await _mediator.Send(model);
            return Ok(employeeDTO);
        }

        /// <summary>
        /// This action will terminate an employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/employees/changeStatus")]
        public async Task<ActionResult<EmployeeDTO>> TerminateEmployeeById([FromBody] ChangeEmployeeStatusCommand model)
        {
            if (!ModelState.IsValid) return BadRequest();
            EmployeeDTO employeeDTO = await _mediator.Send(model);
            return Ok(employeeDTO);
        }



    }
}
