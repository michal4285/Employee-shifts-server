
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
    public class InstitutionDetailsController:ApiController
    {
        InstitutionDtailsBL institutionDetailsBL = new InstitutionDtailsBL();

        //GET api/InstitutionDetails

        [HttpGet]
        public Response GetInstitutionDetail(int id)
        {
            Response res = new Response();
            try
            {
                DTO.InstitutionDetails institution = institutionDetailsBL.getInstitutionDetails(id);
                res.StatusCode = HttpStatusCode.OK;
                res.Data = institution;
                res.IsError = institution == null;

                if (institution == null)
                    res.Message = "you have a mistake,institution isn't exist,id:{id}";

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
                List<DTO.InstitutionDetails> institution = institutionDetailsBL.GetAllInstitutionDetails();

                res.StatusCode = HttpStatusCode.OK;
                res.Data = institution;
                res.IsError = institution == null;
            }
            catch (Exception ex)
            {
                res.StatusCode = HttpStatusCode.OK;
                res.IsError = true;
                res.Message = ex.ToString();
            }
            return res;
        }

        //POST api/InstitutionDetail

        [HttpPost]
        public Response Post(InstitutionDetails institution)
        {
            Response res = new Response();

            try
            {
                DTO.InstitutionDetails i = institutionDetailsBL.CreateConstraintInstitutionDetails(institution);

                res.StatusCode = HttpStatusCode.OK;
                res.Data = i;
                res.IsError = false;

                if (i == null)
                {
                    res.Message = $"Institution's id: {institution.institutionId} is already exist";
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


