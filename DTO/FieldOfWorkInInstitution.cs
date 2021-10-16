using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FieldOfWorkInInstitution
    {
        public int fieldOfWorkId { get; set; }
        public int? institutionId { get; set; }
        public string fieldOfWorkName { get; set; }
        public int? numOfFullTimeShift { get; set; }
        public int? numOfPartTimeShift { get; set; }
        public int? numOfEmployeesInWeeklyShift { get; set; }
    }
}
