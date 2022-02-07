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
        public string settingName { get; set; }
        public int? settingValueInt { get; set; }
        public DateTime? settingValueDate { get; set; }
        public string settingValueString { get; set; }

    }
}
