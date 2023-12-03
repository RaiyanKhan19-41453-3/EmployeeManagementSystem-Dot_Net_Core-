using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EF.Models
{
    public class tblEmployee
    {
        [Key]
        public int employeeId {  get; set; }


        public string employeeName { get; set; } = "";

        [Required]
        public string employeeCode { get; set; } = "";

        [Required]
        public int employeeSalary { get; set; }

        
        public int supervisorId { get; set; }



        public virtual ICollection<tblEmployeeAttendance> employeeAttendances { get; set; }

        public tblEmployee()
        {
            employeeAttendances = new List<tblEmployeeAttendance>();
        }
    }
}
