using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeMonthShifts
    {
        public int employeeShiftId { get; set; }
        public int? employeeId { get; set; }
        public string title { get; set; }
        public DateTime? startShift { get; set; }
        public DateTime? endShift { get; set; }
    }
}
