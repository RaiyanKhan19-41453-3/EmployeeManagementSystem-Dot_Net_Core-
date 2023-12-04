using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EF.Models
{
    public class tblEmployeeAttendance
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Employee")]
        public int employeeId { get; set; }

        [Required]
        public DateTime attendanceDate { get; set; }

        [Required]
        public int isPresent { get; set; }

        [Required]
        public int isAbsent { get; set; }

        [Required]
        public int isOffday { get; set; }

        


        public virtual tblEmployee Employee { get; set; }
    }
}
