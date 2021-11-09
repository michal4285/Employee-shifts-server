using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Converters;
namespace BL
{
   public class DialogueBL
    {
        Entities NTT = new Entities();
       public DTO.Dialogue getDialogue(int id)
        {
            var res = NTT.Dialogue.FirstOrDefault(x => x.dialogueId == id);
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;

        }
        public List<DTO.Dialogue> GetAllDialogues()
        {
            var res = NTT.Dialogue.Select(x => DTO.DTOConvertor.ConvertToDTO(x)).ToList();
            return res != null ? res : null;
        }
        public DTO.Dialogue CreateDialogue(DTO.Dialogue d)
        {
            var dialogue = NTT.Dialogue.FirstOrDefault(e => e.dialogueId==d.dialogueId);

            Dialogue res = dialogue == null ? NTT.Dialogue.Add(DTO.DTOConvertor.ConvertToDTO(d)) : null;
            NTT.SaveChanges();
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;
        }
    }
}
