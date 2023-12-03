using AutoMapper;
using BusinessLogisLayer.DTOs;
using BusinessLogisLayer.IServices;
using DataAccesLayer.EF.Models;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogisLayer.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IRepo<tblEmployee, bool> _employeeRepo;
        private readonly IRepo<tblEmployeeAttendance, bool> _employeeAttendanceRepo;
        public EmployeeService(IRepo<tblEmployee, bool> employeeRepo, 
                               IRepo<tblEmployeeAttendance, bool> employeeAttendanceRepo)
        {
            _employeeRepo = employeeRepo;
            _employeeAttendanceRepo = employeeAttendanceRepo;
        }

        public List<tblEmployeeDTO> GetEmployees()
        {
            var data = _employeeRepo.GetAll();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<tblEmployee, tblEmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<tblEmployeeDTO>>(data);

            return cnvrt;
        }

        public bool AddEmployee(tblEmployeeDTO empDTO)
        {
            var empList = _employeeRepo.GetAll().Where(s => s.employeeCode == empDTO.employeeCode).ToList();
            if(empList.Count > 0) { return false; }

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<tblEmployeeDTO, tblEmployee>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<tblEmployee>(empDTO);

            return _employeeRepo.Create(cnvrt);
        }

        public bool UpdateEmployee(tblEmployeeDTO empDTO)
        {
            var data = _employeeRepo.Get(empDTO.employeeId);

            var empList = _employeeRepo.GetAll().Where(s => s.employeeCode == empDTO.employeeCode).ToList();
            if (empList.Count > 0) { return false; }

            data.employeeName = empDTO.employeeName;
            data.employeeCode = empDTO.employeeCode;

            return _employeeRepo.Update(data);
        }

        public tblEmployeeDTO GetHighestSalaryByPosition(int position = 1)
        {
            if(position < 1) { return null; }
            var data = _employeeRepo.GetAll().OrderByDescending(emp => emp.employeeSalary).Skip(position - 1).Take(1).FirstOrDefault();
            
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<tblEmployee, tblEmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<tblEmployeeDTO>(data);

            return cnvrt;
        }

        public List<tblEmployeeDTO> GetEmpWithoutAbsenceOnSalaryMaxToMin()
        {
            var data = (from emp in _employeeRepo.GetAll()
                        where emp.employeeAttendances.All(attendance => attendance.isAbsent == 0)
                        orderby emp.employeeSalary descending
                        select emp).ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<tblEmployee, tblEmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<tblEmployeeDTO>>(data);

            return cnvrt;
        }

        public bool AddEmployeeAttendance(tblEmployeeAttendanceDTO empAttendanceDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<tblEmployeeAttendanceDTO, tblEmployeeAttendance>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<tblEmployeeAttendance>(empAttendanceDTO);

            return _employeeAttendanceRepo.Create(cnvrt);
        }

        public List<AttendanceReportDTO> GetAttendanceReport()
        {
            return (from record in _employeeAttendanceRepo.GetAll()
                    group record by new { record.employeeId, record.attendanceDate.Year, record.attendanceDate.Month } into grp
                    select new AttendanceReportDTO
                    {
                        EmployeeId = grp.Key.employeeId,
                        EmployeeName = grp.FirstOrDefault().Employee.employeeName,
                        Year = grp.Key.Year.ToString(), 
                        Month = ConvertMonthToString(grp.Key.Month),
                        PayableSalary = grp.FirstOrDefault().Employee.employeeSalary,
                        TotalPresent = grp.Count(r => r.isPresent == 1),
                        TotalAbsent = grp.Count(r => r.isAbsent == 1),
                        TotalOffDay = grp.Count(r => r.isOffday == 1)
                    }).ToList();
        }

        public List<tblEmployeeDTO> HeirarchyBasedOnSupervisor(int empId)
        {
            var data = _employeeRepo.Get(empId);
            List<tblEmployee> empList = new List<tblEmployee>();
            empList.Add(data);

            while (data.supervisorId != 0)
            {
                empList.Add(_employeeRepo.Get(data.supervisorId));
                data = _employeeRepo.Get(data.supervisorId);
            }

            var dataDTO = new List<tblEmployeeDTO>();
            foreach (var emp in empList)
            {
                dataDTO.Add(new tblEmployeeDTO
                {
                    employeeId = emp.employeeId,
                    employeeName = emp.employeeName,
                    employeeCode = emp.employeeCode,
                    employeeSalary = emp.employeeSalary,
                    supervisorId = emp.supervisorId
                });
            }

            return dataDTO;
        }

        public string ConvertMonthToString(int month)
        {
            switch (month)
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";
                case 11: return "November";
                case 12: return "December";
                default: return "Invalid Month";
            }
        }
    }
}
