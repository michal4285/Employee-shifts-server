using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class EmployeeLimit
    {
        public int employeeShiftId;

        public int restrictionId { get; set; }
        public int? employeeInInstitutionId { get; set; }
        public DateTime? date { get; set; }
        public int? shiftInInstitutionId { get; set; }
        public int? substituteEmployeeId { get; set; }
    }
}
