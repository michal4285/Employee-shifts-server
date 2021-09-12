using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Dialogue: IConvertable
    {
        public int dialogueId { get; set; }
        public int? employeeInInstitutionId { get; set; }
        public string status { get; set; }
        public string text { get; set; }
        public DateTime? date { get; set; }
    }
}

        
