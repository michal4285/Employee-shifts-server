using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class ShiftInstitutionBL
    {
        Entities NTT = new Entities();

        public List<DTO.ShiftInstitutionDTO> getInstitutionShifts(int InstitutionId)
        {
            var res = NTT.ShiftInstitution.Where(e => e.institutionId == InstitutionId).Select(x => DTO.DTOConvertor.ConvertToDTO(x)).ToList();
            return res != null ? res : null;

        }
        public List<DTO.ShiftInstitutionDTO> getShifts()
        {
            var res = NTT.ShiftInstitution.Select(e => DTO.DTOConvertor.ConvertToDTO(e)).ToList();
            return res != null ? res : null;
        }
        public DTO.ShiftInstitutionDTO addshift(DTO.ShiftInstitutionDTO ShiftInstitution)
        {
            var res = NTT.ShiftInstitution.Add(DTO.DTOConvertor.ConvertToDTO(ShiftInstitution));
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;
        }

    }
}
