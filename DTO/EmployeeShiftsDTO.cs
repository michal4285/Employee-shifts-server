using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeShiftsDTO:IConvertable
    {

        public int employeeShiftId { get; set; }
        public int? employeeInInstitutionId { get; set; }
        public DateTime? Date { get; set; }
        public int? ShiftId { get; set; }
    }
}
