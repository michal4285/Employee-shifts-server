using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Converters;

namespace BL
{
    public class EmployeeDetailBL
    {
        Entities1 NTT = new Entities1();

        //public IEnumerable<DTO.EmployeeDetail> GetEmployeeDetail()
        //{
        //    var list = DAL.EmployeeDetailDal.GetEmployeeDetail();
        //    foreach (var EmployeeDetail in list)
        //    {
        //        yield return Converters.Converter.ConvertToDTO<DAL.EmployeeDetail, DTO.EmployeeDetail>(EmployeeDetail);
        //    }
        //}

        public DTO.EmployeeDetail CheckLogin(string email, string password)
        {
            var res = NTT.EmployeeDetails.FirstOrDefault(e => e.employeePassword == password && e.employeeEmail == email);
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;
        }

        public DTO.EmployeeDetail Register(DTO.EmployeeDetail employeeDetail)
        {
               var employee = NTT.EmployeeDetails.FirstOrDefault(e => e.employeeEmail == employeeDetail.employeeEmail);
           
                EmployeeDetails res = employee == null ? NTT.EmployeeDetails.Add(DTO.DTOConvertor.ConvertToDTO(employeeDetail)):null;
                NTT.SaveChanges();
                return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;
        }
        public List<DTO.EmployeeDetail> GetAllEmloyees()
        {
         var res=NTT.EmployeeDetails.Select(x=> DTO.DTOConvertor.ConvertToDTO(x)).ToList();
            return res != null ? res :null;
        }

        //public static bool UpDate(int id, string value)
        //{
        //    try
        //    {

        //        DAL.EmployeeDetailDal.update(id, value);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        //public static bool delete(int id)
        //{
        //    try
        //    {

        //        DAL.EmployeeDetailDal.delete(id);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
    }
}
