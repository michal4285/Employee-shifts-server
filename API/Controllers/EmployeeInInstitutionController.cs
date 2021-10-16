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
    public class EmployeeInInstitutionController:ApiController
    {
        EmployeeInInstitutionBL employeeInInstitutionBL = new EmployeeInInstitutionBL();

        //GET api/EmployeeInInstitution

        [HttpGet]
        public Response GetEmployeeInInstitution(int id)
        {
            Response res = new Response();
            try
            {
                DTO.EmployeeInInstitution employeeInInstitution = employeeInInstitutionBL.getEmployeeInInstitution(id);
                res.StatusCode = HttpStatusCode.OK;
                res.Data = employeeInInstitution;
                res.IsError = employeeInInstitution == null;

                if (employeeInInstitution == null)
                    res.Message = "you have a mistake,employeeInInstitution isn't exist,id:{id}";

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
                List<DTO.EmployeeInInstitution> employeeInInstitution = employeeInInstitutionBL.GetAllEmployeeInInstitution();

                res.StatusCode = HttpStatusCode.OK;
                res.Data = employeeInInstitution;
                res.IsError = employeeInInstitution == null;
            }
            catch (Exception ex)
            {
                res.StatusCode = HttpStatusCode.OK;
                res.IsError = true;
                res.Message = ex.ToString();
            }
            return res;
        }

        //POST api/EmployeeInInstitution

        [HttpPost]
        public Response Post(EmployeeInInstitution employeeInInstitution)
        {
            Response res = new Response();

            try
            {
                DTO.EmployeeInInstitution e = employeeInInstitutionBL.CreateEmployeeInInstitution(employeeInInstitution);

                res.StatusCode = HttpStatusCode.OK;
                res.Data =e;
                res.IsError = false;

                if (e == null)
                {
                    res.Message = $"EmployeeInInstitution's id: {employeeInInstitution.employeeInInstitutionId} is already exist";
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




