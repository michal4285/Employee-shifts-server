using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IConvertable { }
    partial class EmployeeDetail : IConvertable { }
    partial class Dialogue : IConvertable { }
    
}
