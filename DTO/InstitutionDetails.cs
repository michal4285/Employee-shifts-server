using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class InstitutionDetails
    {
        public int institutionId { get; set; }
        public string institutionName { get; set; }
        public string institutionAddress { get; set; }
        public string institutionEmail { get; set; }
        public string institutionPhone { get; set; }
        public int? institutionManagerId { get; set; }
        public int? numOfShift { get; set; }
    }
}
