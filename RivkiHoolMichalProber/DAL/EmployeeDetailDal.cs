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
        public static void createEmployee(EmployeeDetail employeeDetail)
        {
            using (Entities1 DB = new Entities1())
            {
                 DB.EmployeeDetails.Add(employeeDetail);
                DB.SaveChanges();

            }
        }
        public static void update(int id,string value)
        {
            using (Entities1 DB = new Entities1())
            {
                 DB.EmployeeDetails.FirstOrDefault(e=>e.employeeId==id).employeePassword=value;
            }
        }
        public static void delete(int id)
        {
            using (Entities1 DB = new Entities1())
            {
                DB.EmployeeDetails.Remove(DB.EmployeeDetails.FirstOrDefault(e=>e.employeeId==id));
            }
        }
    }
}
