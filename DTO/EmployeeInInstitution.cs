using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeInInstitution 
    {
        public int employeeInInstitutionId { get; set; }
        public int? employeerId { get; set; }
        public int? institutionId { get; set; }
        public int? fieldOfWorkId { get; set; }
        public string status { get; set; }
        public string shiftType { get; set; }
    }
}
