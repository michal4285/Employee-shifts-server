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
    public class EmployeeController : ApiController
    {
        EmployeeDetailBL employeeDetailBL = new EmployeeDetailBL();

        [HttpGet]
        public Response Login(string email, string password)
        {
            Response res = new Response();

            try
            {
                DTO.EmployeeDetail employee = employeeDetailBL.CheckLogin(email, password);
                
                res.StatusCode = HttpStatusCode.OK;
                res.Data = employee;
                res.IsError = employee == null;

                if (employee == null)
                {
                    res.Message = $"Employee is not exist, email: {email}, password: {password} ";
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
        public Response GetAll()
        {
            Response res = new Response();

            try
            {

                List<DTO.EmployeeDetail> employees = employeeDetailBL.GetAllEmloyees();

                res.StatusCode = HttpStatusCode.OK;
                res.Data = employees;
                res.IsError = employees == null;
            }

            catch (Exception ex)
            {
                res.StatusCode = HttpStatusCode.OK;
                res.IsError = true;
                res.Message = ex.ToString();
            }

            return res;
        }

        // GET: api/Employee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee

        [HttpPost]
        public Response Post(EmployeeDetail employeeDetail)
        {
            Response res = new Response();

            try
            {
                DTO.EmployeeDetail employee = employeeDetailBL.Register(employeeDetail);

                res.StatusCode = HttpStatusCode.OK;
                res.Data = employee;
                res.IsError = false;

                if (employee == null)
                {
                    res.Message = $"employee's email: {employeeDetail.employeeEmail} is already exist";
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
        // PUT: api/Employee/5
        public Response Update(EmployeeDetail employeeDetail)
        {
            Response res = new Response();

            try
            {
                DTO.EmployeeDetail employee = employeeDetailBL.update(employeeDetail);

                res.StatusCode = HttpStatusCode.OK;
                res.Data = employee;
                res.IsError = false;

                if (employee == null)
                {
                    res.Message = $"employee's email: {employeeDetail.employeeEmail} is already exist";
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

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}
