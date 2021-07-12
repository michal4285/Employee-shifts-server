using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class DialogueController:ApiController
    {
        ////GET api/Dialogue
        //public IEnumerable<DTO.Dialogue> Get()
        //{
        //    return BL.DialogueBL.GetDialogue();
        //}
        //GET api/dialogue/:id
        [HttpGet]
        [Route("api/Dialogue/ReturnDialogue")]
        public bool ReturnDialogue(int id)
        {
            return BL.DialogueBL.ReturnDialogue(id);
        }

        //POST api/dialogue
        public bool Post([FromBody] DTO.Dialogue dialogue)
        {
            return BL.DialogueBL.AddDialogue(dialogue);
        }

        //DELETE api/dialogue/5
        public bool Delete(int id)
        {
            return BL.DialogueBL.delete(id);

        }
    }
}

    

 

      
        

 