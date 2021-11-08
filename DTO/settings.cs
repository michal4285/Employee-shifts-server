using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class settings 
    {
        public int settingId { get; set; }
        public  int? institutionId { get; set; }
        public int? freeDaysNum { get; set; }
        public int? freeShiftsNum { get; set; }

    }
}
