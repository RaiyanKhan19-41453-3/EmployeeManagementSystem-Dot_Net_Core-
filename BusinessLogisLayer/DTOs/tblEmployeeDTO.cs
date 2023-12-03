using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogisLayer.DTOs
{
    public class tblEmployeeDTO
    {
        public int employeeId { get; set; }

        public string employeeName { get; set; }

        public string employeeCode { get; set; }

        public int employeeSalary { get; set; }

        public int supervisorId { get; set; }
    }
}
