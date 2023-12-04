using BusinessLogisLayer.DTOs;
using BusinessLogisLayer.IServices;
using BusinessLogisLayer.Services;
using EmployeeManagement.AuthFilters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("api/emp")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("getEmp")]
        public IActionResult GetEmployees()
        {
            try
            {
                var data = _employeeService.GetEmployees().ToList();
                
                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddEmp")]
        public IActionResult InsertEmployee([FromBody] tblEmployeeDTO empDTO)
        {
            try
            {
                var data = _employeeService.AddEmployee(empDTO);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch]
        [Route("UpdateEmp")]
        public IActionResult UpdateEmployee([FromBody] tblEmployeeDTO employeeDTO)
        {
            try
            {
                var data = _employeeService.UpdateEmployee(employeeDTO);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetHigesetSalaryByPosition/{position}")]
        public IActionResult GetHigesetSalaryByPosition(int position)
        {
            try
            {
                var data = _employeeService.GetHighestSalaryByPosition(position);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetEmpWithoutAbsenceOnSalaryMaxToMin")]
        public IActionResult GetEmpWithoutAbsenceOnSalaryMaxToMin()
        {
            try
            {
                var data = _employeeService.GetEmpWithoutAbsenceOnSalaryMaxToMin();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddEmployeeAttendance")]
        public IActionResult AddEmployeeAttendance([FromBody] tblEmployeeAttendanceDTO attendanceDTO)
        {
            try
            {
                var data = _employeeService.AddEmployeeAttendance(attendanceDTO);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        //[ServiceFilter(typeof(Logged))]
        [Logged]
        [HttpGet]
        [Route("GetAttendanceReport")]
        public IActionResult AttendanceReport()
        {
            try
            {
                var data = _employeeService.GetAttendanceReport();
                return Ok(data);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("HeirarchyBasedOnSuperviser/{id}")]
        public IActionResult HeirarchyBasedOnSuperviser(int id)
        {
            try
            {
                var data = _employeeService.HeirarchyBasedOnSupervisor(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}