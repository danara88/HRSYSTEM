using HRSYSTEM.application;
using HRSYSTEM.domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<ApiResponse<CreateEmployeeDTO>>> CreateEmployee([FromBody] CreateEmployeeCommand model)
        {
            if (!ModelState.IsValid) return BadRequest();
            CreateEmployeeDTO response = await _mediator.Send(model);
            return Ok(new ApiResponse<CreateEmployeeDTO>(response));
        }
           
        /// <summary>
        /// This method will return all the employees paginated
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/employees")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetEmployeesDTO>>>> GetAllEmployees([FromQuery] PaginateEmployeeQueryFilter filters)
        {
            if (!ModelState.IsValid) return BadRequest();
            PagedList<GetEmployeesDTO> employeesDTO = await _mediator.Send(new GetEmployeesQuery(filters));
            var metadata = new Metadata
            {
                TotalCount = employeesDTO.TotalCount,
                PageSize = employeesDTO.PageSize,
                CurrentPage = employeesDTO.CurrentPage,
                TotalPages = employeesDTO.TotalPages,
                HasNextPage = employeesDTO.HasNextPage,
                HasPreviousPage = employeesDTO.HasPreviousPage
            };
            var response = new ApiResponse<IEnumerable<GetEmployeesDTO>>(employeesDTO)
            {
                Metadata = metadata
            };
            return Ok(response);

        }

        /// <summary>
        /// This action will return one employee
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/employee/{id}")]
        public async Task<ActionResult<ApiResponse<EmployeeDTO>>> GetEmployeeById(int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            EmployeeDTO employeeDTO = await _mediator.Send(new GetEmployeeQuery(id));
            return Ok(new ApiResponse<EmployeeDTO>(employeeDTO));
        }

        /// <summary>
        /// This action will update an employee
        /// </summary>
        /// <param name="employeeDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/employees/{id}")]
        public async Task<ActionResult<ApiResponse<EmployeeDTO>>> UpdateEmployeeById([FromBody] UpdateEmployeeCommand model)
        {
            if (!ModelState.IsValid) return BadRequest();
            EmployeeDTO employeeDTO = await _mediator.Send(model);
            return Ok(new ApiResponse<EmployeeDTO>(employeeDTO));
        }

        /// <summary>
        /// This action will terminate an employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/employees/changeStatus")]
        public async Task<ActionResult<ApiResponse<EmployeeDTO>>> TerminateEmployeeById([FromBody] ChangeEmployeeStatusCommand model)
        {
            if (!ModelState.IsValid) return BadRequest();
            EmployeeDTO employeeDTO = await _mediator.Send(model);
            return Ok(new ApiResponse<EmployeeDTO>(employeeDTO));
        }



    }
}
