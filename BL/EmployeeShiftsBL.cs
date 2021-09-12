using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
   public class EmployeeShiftsBL
    {
        Entities1 NTT = new Entities1();

        public List<DTO.EmployeeShiftsDTO> getUserShifts(int userID)
        {
            var res = NTT.EmployeeShifts.Where(e => e.employeeInInstitutionId == (NTT.EmployeeInInstitution.FirstOrDefault(i => i.employeerId == userID).employeeInInstitutionId)).Select(x=> DTO.DTOConvertor.ConvertToDTO(x)).ToList();
            return res != null ? res : null;
          
        }
        public List<DTO.EmployeeShiftsDTO> getShifts()
        {
            var res = NTT.EmployeeShifts.Select(e => DTO.DTOConvertor.ConvertToDTO(e)).ToList();
            return res != null ? res : null;
        }
        public DTO.EmployeeShiftsDTO addshift(DTO.EmployeeShiftsDTO EmployeeShiftsDTO)
        {
            var res = NTT.EmployeeShifts.Add(DTO.DTOConvertor.ConvertToDTO(EmployeeShiftsDTO));
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;
        }
    }
}
