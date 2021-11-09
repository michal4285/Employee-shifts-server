using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Converters;

namespace BL
{
    public class EmployeeInInstitutionBL
    {
        Entities NTT = new Entities();
        public DTO.EmployeeInInstitution getEmployeeInInstitution(int id)
        {
            var res = NTT.EmployeeInInstitution.FirstOrDefault(x => x.employeeInInstitutionId == id);
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;

        }
        public List<DTO.EmployeeInInstitution> GetAllEmployeeInInstitution()
        {
            var res = NTT.EmployeeInInstitution.Select(x => DTO.DTOConvertor.ConvertToDTO(x)).ToList();
            return res != null ? res : null;
        }
        public DTO.EmployeeInInstitution CreateEmployeeInInstitution(DTO.EmployeeInInstitution e)
        {
            var employeeInInstitution = NTT.EmployeeInInstitution.FirstOrDefault(x => x.employeeInInstitutionId == e.employeeInInstitutionId);

            EmployeeInInstitution res = employeeInInstitution == null ? NTT.EmployeeInInstitution.Add(DTO.DTOConvertor.ConvertToDTO(e)) : null;
            NTT.SaveChanges();
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;
        }
    }
}

