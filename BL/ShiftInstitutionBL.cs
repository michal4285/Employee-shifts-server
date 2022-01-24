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
            var res = NTT.ShiftInstitution.Select(x => new DTO.ShiftInstitutionDTO
            {
                institutionId=x.institutionId,
                shiftNum=x.shiftNum,
                shiftDescription=x.shiftDescription,
                startTime=x.startTime,
                EndTime=x.EndTime
            }).ToList();

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
