using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogisLayer.DTOs
{
    public class AttendanceReportDTO
    {
        public int EmployeeId { get; set; }


        public string EmployeeName { get; set; }


        public string Year { get; set; }


        public string Month { get; set; }


        public int PayableSalary { get; set; }


        public int TotalPresent { get; set; }


        public int TotalAbsent { get; set; }


        public int TotalOffDay { get; set; }
    }
}
