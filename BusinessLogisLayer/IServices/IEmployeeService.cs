using BusinessLogisLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogisLayer.IServices
{
    public interface IEmployeeService
    {
        List<tblEmployeeDTO> GetEmployees();
        bool AddEmployee(tblEmployeeDTO empDTO);
        bool UpdateEmployee(tblEmployeeDTO empDTO);
        tblEmployeeDTO GetHighestSalaryByPosition(int position = 1);
        bool AddEmployeeAttendance(tblEmployeeAttendanceDTO empAttendanceDTO);
        List<tblEmployeeDTO> HeirarchyBasedOnSupervisor(int empId);
        List<AttendanceReportDTO> GetAttendanceReport();
        List<tblEmployeeDTO> GetEmpWithoutAbsenceOnSalaryMaxToMin();
    }
}
