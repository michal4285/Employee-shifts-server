using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeDetail : IConvertable
    {
        public int employeeId { get; set; }
        public string employeeFirstName { get; set; }
        public string employeeLastName { get; set; }
        public string employeeAddress { get; set; }
        public string employeePhone { get; set; }
        public string employeeEmail { get; set; }
        public string employeePassword { get; set; }
    }
}
