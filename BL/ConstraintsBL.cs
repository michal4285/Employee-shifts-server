using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Converters;

namespace BL
{
   public class ConstraintsBL
    {
        Entities NTT = new Entities();
        public DTO.Constraints getConstraint(int id)
        {
            var res = NTT.Constraints.FirstOrDefault(x => x.constraintId == id);
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;

        }
        public List<DTO.Constraints> GetAllConstraints()
        {
            var res = NTT.Constraints.Select(x => DTO.DTOConvertor.ConvertToDTO(x)).ToList();
            return res != null ? res : null;
        }
        public DTO.Constraints CreateConstraint(DTO.Constraints c)
        {
            var constraint = NTT.Constraints.FirstOrDefault(e => e.constraintId == c.constraintId);

            Constraints res = constraint == null ? NTT.Constraints.Add(DTO.DTOConvertor.ConvertToDTO(c)) : null;
            NTT.SaveChanges();
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;
        }
    }
}



