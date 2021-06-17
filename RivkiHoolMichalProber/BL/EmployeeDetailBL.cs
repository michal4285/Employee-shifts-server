using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class EmployeeDetailBL
    {
        public static IEnumerable<DTO.EmployeeDetail> GetEmployeeDetail()
        {
            var list = DAL.EmployeeDetailDal.GetEmployeeDetail();
            foreach (var EmployeeDetail in list)
            {
                yield return Converters.Converter.ConvertToDTO<DAL.EmployeeDetail, DTO.EmployeeDetail>(EmployeeDetail);
            }
        }

        public static bool CheckLogin(string email, string password)
        {
            var currentEmployee =  DAL.EmployeeDetailDal.GetEmployee(email,password);
            return currentEmployee != null;

        }

        public static bool Register(DTO.EmployeeDetail employeeDetail)
        {
            try
            {

                DAL.EmployeeDetailDal.createEmployee(Converters.Converter.ConvertToEntity<DTO.EmployeeDetail,DAL.EmployeeDetail>(employeeDetail));
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public static bool UpDate(int id,string value)
        {
            try
            {

                DAL.EmployeeDetailDal.update(id,value);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool delete(int id)
        {
            try
            {

                DAL.EmployeeDetailDal.delete(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
