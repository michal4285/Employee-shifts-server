using API.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;

namespace API.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DialogueController:ApiController
    {
        DialogueBL dialogueBL = new DialogueBL();

        //GET api/Dialogue

        [HttpGet]
        public Response GetDialogue(int id)
        {
            Response res = new Response();
            try
            {
                DTO.Dialogue dialogue = dialogueBL.getDialogue(id);
                res.StatusCode = HttpStatusCode.OK;
                res.Data = dialogue;
                res.IsError = dialogue == null;

                if (dialogue == null)
                    res.Message = "you have a mistake,dialogue isn't exist,id:{id}";

            }
            catch (Exception ex)
            {

                res.StatusCode = HttpStatusCode.OK;
                res.IsError = true;
                res.Message = ex.ToString();
            }
            return res;
        }
        [HttpGet]
        public Response GetAll()
        {
            Response res = new Response();
            try
            {
                List<DTO.Dialogue> dialogue = dialogueBL.GetAllDialogues();

                res.StatusCode = HttpStatusCode.OK;
                res.Data = dialogue;
                res.IsError = dialogue == null;
            }
            catch (Exception ex)
            {
                res.StatusCode = HttpStatusCode.OK;
                res.IsError = true;
                res.Message = ex.ToString();
            }
            return res;
        }

        //POST api/Dialogue

        [HttpPost]
        public Response Post(Dialogue dialogue)
        {
            Response res = new Response();

            try
            {
                DTO.Dialogue d = dialogueBL.CreateDialogue(dialogue);

                res.StatusCode = HttpStatusCode.OK;
                res.Data = d;
                res.IsError = false;

                if (d == null)
                {
                    res.Message = $"Dialogue's id: {dialogue.dialogueId} is already exist";
                }
            }
            catch (Exception ex)
            {
                res.StatusCode = HttpStatusCode.OK;
                res.IsError = true;
                res.Message = ex.ToString();
            }
            return res;
        }
    }
}


