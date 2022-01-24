using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Converters;


namespace BL
{
   public class InstitutionDtailsBL
    {
        Entities NTT = new Entities();
        public DTO.InstitutionDetails getInstitutionDetails(int id)
        {
            var res = NTT.InstitutionDtails.FirstOrDefault(x => x.institutionId == id);
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;

        }
        public List<DTO.InstitutionDetails> GetAllInstitutionDetails()
        {
            var res = NTT.InstitutionDtails.Select(x => new DTO.InstitutionDetails
            {
                institutionName=x.institutionName,
                institutionAddress=x.institutionAddress,
                institutionEmail=x.institutionEmail,
                institutionPhone=x.institutionPhone,
                institutionManagerId=x.institutionManagerId,
                numOfShift=x.numOfShift
            }).ToList();

            return res != null ? res : null;
        }
        public DTO.InstitutionDetails CreateConstraintInstitutionDetails(DTO.InstitutionDetails i)
        {
            var institutionDetails = NTT.InstitutionDtails.FirstOrDefault(e => e.institutionId == i.institutionId);

            InstitutionDtails res = institutionDetails == null ? NTT.InstitutionDtails.Add(DTO.DTOConvertor.ConvertToDTO(i)) : null;
            NTT.SaveChanges();
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;
        }
    }
}





