using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using API.Models;

namespace API.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FieldOfWorkInInstitutionController:ApiController
    {
        FieldOfWorkInInstitutionBL fieldOfWorkInInstitutiontBL = new FieldOfWorkInInstitutionBL();

        //GET api/FieldOfWorkInInstitution

        [HttpGet]
        public Response GetFieldOfWorkInInstitution(int id)
        {
            Response res = new Response();
            try
            {
                DTO.FieldOfWorkInInstitution fieldOfWorkInInstitution = fieldOfWorkInInstitutiontBL.getFieldOfWorkInInstitution(id);
                res.StatusCode = HttpStatusCode.OK;
                res.Data = fieldOfWorkInInstitution;
                res.IsError = fieldOfWorkInInstitution == null;

                if (fieldOfWorkInInstitution == null)
                    res.Message = "you have a mistake,fieldOfWorkInInstitution isn't exist,id:{id}";

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
                List<DTO.FieldOfWorkInInstitution> fieldOfWorkInInstitution = fieldOfWorkInInstitutiontBL.GetAllFieldOfWorkInInstitution();

                res.StatusCode = HttpStatusCode.OK;
                res.Data = fieldOfWorkInInstitution;
                res.IsError = fieldOfWorkInInstitution == null;
            }
            catch (Exception ex)
            {
                res.StatusCode = HttpStatusCode.OK;
                res.IsError = true;
                res.Message = ex.ToString();
            }
            return res;
        }

        //POST api/FieldOfWorkInInstitution

        [HttpPost]
        public Response Post(FieldOfWorkInInstitution fieldOfWorkInInstitution)
        {
            Response res = new Response();

            try
            {
                DTO.FieldOfWorkInInstitution f = fieldOfWorkInInstitutiontBL.CreateFieldOfWorkInInstitution(fieldOfWorkInInstitution);

                res.StatusCode = HttpStatusCode.OK;
                res.Data = f;
                res.IsError = false;

                if (f == null)
                {
                    res.Message = $"Constraint's id: {fieldOfWorkInInstitution.fieldOfWorkId} is already exist";
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



