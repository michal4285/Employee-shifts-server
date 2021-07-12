using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class DialogueBL
    {
        //public static IEnumerable<DTO.Dialogue> GetDialogue()
        //{
        //    var list = DAL.DialogueDal.GetDialogues();
        //    foreach (var Dialogue in list)
        //    {
        //        yield return Converters.Converter.ConvertToDTO<DAL.Dialogue, DTO.Dialogue>(Dialogue);
        //    }
        //}
        public static bool ReturnDialogue(int id)
        {
            var currentDialogue = DAL.DialogueDal.GetDialogue(id);
            return currentDialogue != null;
        }
        public static bool AddDialogue(DTO.Dialogue dialogue)
        {
            try
            {
                DAL.DialogueDal.createDialogue(Converters.Converter.ConvertToEntity<DTO.Dialogue, DAL.Dialogue>(dialogue));
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

                DAL.DialogueDal.delete(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
///
