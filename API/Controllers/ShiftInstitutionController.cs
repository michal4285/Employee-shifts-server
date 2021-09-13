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
    public class ShiftInstitutionController : ApiController
    {
        ShiftInstitutionBL shiftInstitutionBL = new ShiftInstitutionBL();
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        // GET api/<controller>/5
        public Response GetInstitutionShifts(int InstitutionId)
        {
            Response res = new Response();

            try
            {
                
                List<DTO.ShiftInstitutionDTO> shifts = shiftInstitutionBL.getInstitutionShifts(InstitutionId);

                res.StatusCode = HttpStatusCode.OK;
                res.Data = shifts;
                res.IsError = shifts == null;

                if (shifts == null)
                {
                    res.Message = $"Institution doesn't have shifts";
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

        [HttpGet]
        public Response GetShifts()
        {
            Response res = new Response();

            try
            {
                List<DTO.ShiftInstitutionDTO> shifts = shiftInstitutionBL.getShifts();

                res.StatusCode = HttpStatusCode.OK;
                res.Data = shifts;
                res.IsError = shifts == null;

                if (shifts == null)
                {
                    res.Message = "There are no shifts";
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

        [HttpPost]
        // POST api/<controller>
        public Response addShift(DTO.ShiftInstitutionDTO shiftInstitution)
        {
            Response res = new Response();

            try
            {
                DTO.ShiftInstitutionDTO shift = shiftInstitutionBL.addshift(shiftInstitution);

                res.StatusCode = HttpStatusCode.OK;
                res.Data = shift;
                res.IsError = false;
            }

            catch (Exception ex)
            {
                res.StatusCode = HttpStatusCode.OK;
                res.IsError = true;
                res.Message = ex.ToString();
            }

            return res;

        }
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}