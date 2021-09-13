using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class ShiftInstitutionDTO
    {
        public int shiftInstitutionId { get; set; }
        public int? institutionId { get; set; }
        public int? shiftNum { get; set; }
        public string shiftDescription { get; set; }
        public TimeSpan? startTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }
}
