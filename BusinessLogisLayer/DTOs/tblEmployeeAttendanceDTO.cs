using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogisLayer.DTOs
{
    public class tblEmployeeAttendanceDTO
    {
        public int Id { get; set; }

        public int employeeId { get; set; }

        public DateTime attendanceDate { get; set; }

        public int isPresent { get; set; }

        public int isAbsent { get; set; }

        public int isOffday { get; set; }
    }
}
