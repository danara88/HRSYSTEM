﻿using AutoMapper;
using HRSYSTEM.application;
using HRSYSTEM.domain;
using HRSYSTEM.persistance.Repositories.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRSYSTEM.api.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// This action creates a new employee
        /// </summary>
        /// <param name="employeeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/employees")]
        public async Task<ActionResult> CreateEmployee([FromBody] CreateEmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<EmployeeEntity>(employeeDTO);
            await _employeeRepository.CreateEmployee(employee);
            return Ok();
        }
           
        /// <summary>
        /// This action will return all the employees of the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/employees")]
        public async Task<ActionResult<IEnumerable<GetEmployeesDTO>>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetEmployees();
            var employeesDTO = _mapper.Map<IEnumerable<GetEmployeesDTO>>(employees);
            return Ok(employeesDTO);
        }

        /// <summary>
        /// This action will return one employee
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/employees/{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            return Ok(employeeDTO);
        }



    }
}