using API.Models;
using BL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace API.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeShiftsController : ApiController
    {
        EmployeeShiftsBL employeeShiftsBL = new EmployeeShiftsBL();
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        [HttpGet]
        // GET api/<controller>/5
        public Response UserShifts(int employeeId)
        {
            Response res = new Response();

            try
            {
                List<DTO.EmployeeShiftsDTO> employee = employeeShiftsBL.getUserShifts(employeeId);

                res.StatusCode = HttpStatusCode.OK;
                res.Data = employee;
                res.IsError = employee == null;

                if (employee == null)
                {
                    res.Message = $"Employee doesn't have shifts";
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
        public Response GetShift()
        {
            Response res = new Response();

            try
            {
                List<DTO.EmployeeShiftsDTO> employee = employeeShiftsBL.getShifts();

                res.StatusCode = HttpStatusCode.OK;
                res.Data = employee;
                res.IsError = employee == null;

                if (employee == null)
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
        public Response addShift(EmployeeShiftsDTO EmployeeShifts)
        {
            Response res = new Response();

            try
            {
                DTO.EmployeeShiftsDTO employee = employeeShiftsBL.addshift(EmployeeShifts);

                res.StatusCode = HttpStatusCode.OK;
                res.Data = employee;
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