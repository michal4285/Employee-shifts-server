using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET api/Employee
        public IEnumerable<DTO.EmployeeDetail> Get()
        {
            return  BL.EmployeeDetailBL.GetEmployeeDetail();
        }

        // GET api/employee/:email/:password

        public bool Login(string email,string password)
        {
            return  BL.EmployeeDetailBL.CheckLogin(email,password);
        }


        // POST api/employee
        public bool Post([FromBody]DTO.EmployeeDetail employeeDetail)
        {
            return BL.EmployeeDetailBL.Register(employeeDetail);
        }

        // PUT api/employee/:id
        public bool Put(int id, [FromBody]string value)
        {
             return BL.EmployeeDetailBL.UpDate(id, value);
        }

        // DELETE api/employee/5
        public bool Delete(int id)
        {
           return BL.EmployeeDetailBL.delete(id);
        }
    }
}
