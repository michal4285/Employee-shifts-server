
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
    public class EmployeeLimitController:ApiController
    {
        EmployeeLimitBL employeeLimitBL = new EmployeeLimitBL();

        //GET api/EmployeeLimit

        [HttpGet]
        public Response GetEmployeeLimit(int id)
        {
            Response res = new Response();
            try
            {
                DTO.EmployeeLimit employeeLimit = employeeLimitBL.getEmployeeLimit(id);
                res.StatusCode = HttpStatusCode.OK;
                res.Data = employeeLimit;
                res.IsError = employeeLimit == null;

                if (employeeLimit == null)
                    res.Message = "you have a mistake,employeeLimit isn't exist,id:{id}";

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
                List<DTO.EmployeeLimit> employeeLimit = employeeLimitBL.GetAllEmployeeLimit();

                res.StatusCode = HttpStatusCode.OK;
                res.Data = employeeLimit;
                res.IsError = employeeLimit == null;
            }
            catch (Exception ex)
            {
                res.StatusCode = HttpStatusCode.OK;
                res.IsError = true;
                res.Message = ex.ToString();
            }
            return res;
        }

        //POST api/EmployeeLimit

        [HttpPost]
        public Response Post(EmployeeLimit employeeLimit)
        {
            Response res = new Response();

            try
            {
                DTO.EmployeeLimit e = employeeLimitBL.CreateEmployeeLimit(employeeLimit);

                res.StatusCode = HttpStatusCode.OK;
                res.Data = e;
                res.IsError = false;

                if (e == null)
                {
                    res.Message = $"EmployeeLimit's id: {employeeLimit.employeeShiftId} is already exist";
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



