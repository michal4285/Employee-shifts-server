using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Converters;

namespace BL
{
   public class FieldOfWorkInInstitutionBL
    {
        Entities NTT = new Entities();
        public DTO.FieldOfWorkInInstitution getFieldOfWorkInInstitution(int id)
        {
            var res = NTT.FieldOfWorkInInstitution.FirstOrDefault(x => x.fieldOfWorkId == id);
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;

        }
        public List<DTO.FieldOfWorkInInstitution> GetAllFieldOfWorkInInstitution()
        {
            var res = NTT.FieldOfWorkInInstitution.Select(x => DTO.DTOConvertor.ConvertToDTO(x)).ToList();
            return res != null ? res : null;
        }
        public DTO.FieldOfWorkInInstitution CreateFieldOfWorkInInstitution(DTO.FieldOfWorkInInstitution f)
        {
            var fieldOfWorkInInstitution = NTT.FieldOfWorkInInstitution.FirstOrDefault(e => e.fieldOfWorkId == f.fieldOfWorkId);

            FieldOfWorkInInstitution res = fieldOfWorkInInstitution == null ? NTT.FieldOfWorkInInstitution.Add(DTO.DTOConvertor.ConvertToDTO(f)) : null;
            NTT.SaveChanges();
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;
        }
    }
}




