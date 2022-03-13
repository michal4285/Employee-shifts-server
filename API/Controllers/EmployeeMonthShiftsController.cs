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
    public class EmployeeMonthShiftsController : ApiController
    {
        EmployeeMonthShiftsBL employeeMonthShiftsBL = new EmployeeMonthShiftsBL();
      
        [HttpGet]
        // GET api/<controller>/5
        public Response UserShifts(int employeeId)
        {
            Response res = new Response();

            try
            {
                List<DTO.EmployeeMonthShifts> employee = employeeMonthShiftsBL.getUserShifts(employeeId);

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
        public Response GetShifts()
        {
            Response res = new Response();

            try
            {
                List<DTO.EmployeeMonthShifts> employee = employeeMonthShiftsBL.getShifts();

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
        public Response addShift(EmployeeMonthShifts EmployeeShifts)
        {
            Response res = new Response();

            try
            {
                DTO.EmployeeMonthShifts employee = employeeMonthShiftsBL.addshift(EmployeeShifts);

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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}