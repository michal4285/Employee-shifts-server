using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public static class EmployeeDetailDal
    {
        public static IEnumerable<EmployeeDetail> GetEmployeeDetail()
        {
            //try
            //{
            using (Entities1 DB = new Entities1())
            {
                return DB.EmployeeDetails.ToList();
            }
            //}
            //catch (Exception e)
            //{
            //    //todo:-------
            //    return null;
            //}
        }

        public static EmployeeDetail GetEmployee(string email, string password)
        {
            using (Entities1 DB= new Entities1())
            {
                return DB.EmployeeDetails.FirstOrDefault(e=>e.employeeEmail==email&&e.employeePassword==password);
            }
        }
    }
}
