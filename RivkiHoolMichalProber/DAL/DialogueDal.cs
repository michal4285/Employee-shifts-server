using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DialogueDal
    {
        //public static IEnumerable<Dialogue> GetDialogues()
        //{
        //    using (Entities1 DB = new Entities1())
        //    {
        //        return DB.Dialogues.ToList();
        //    }
        //}
        public static Dialogue GetDialogue(int id)
        {
            using (Entities1 DB = new Entities1())
            {
                return DB.Dialogues.FirstOrDefault(x => x.employeeInInstitutionId == id);
            }
        }
        public static void createDialogue(Dialogue dialogue)
        {
            using (Entities1 DB = new Entities1())
            {
                DB.Dialogues.Add(dialogue);
                DB.SaveChanges();
            }
        }

        public static void delete(int id)
        {
            using (Entities1 DB=new Entities1())
            {
                DB.Dialogues.Remove(DB.Dialogues.FirstOrDefault(x => x.dialogueId == id));
                DB.SaveChanges();
            }
        }
    }
}
