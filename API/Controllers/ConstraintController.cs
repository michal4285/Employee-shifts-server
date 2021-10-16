
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
    public class ConstraintController:ApiController
    {
        ConstraintsBL constraintBL = new ConstraintsBL();

        //GET api/Constraint

        [HttpGet]
        public Response GetConstraint(int id)
        {
            Response res = new Response();
            try
            {
                DTO.Constraints constraint = constraintBL.getConstraint(id);
                res.StatusCode = HttpStatusCode.OK;
                res.Data = constraint;
                res.IsError = constraint == null;

                if (constraint == null)
                    res.Message = "you have a mistake,constraint isn't exist,id:{id}";

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
                List<DTO.Constraints> constraint = constraintBL.GetAllConstraints();

                res.StatusCode = HttpStatusCode.OK;
                res.Data = constraint;
                res.IsError = constraint == null;
            }
            catch (Exception ex)
            {
                res.StatusCode = HttpStatusCode.OK;
                res.IsError = true;
                res.Message = ex.ToString();
            }
            return res;
        }

        //POST api/Constraints

        [HttpPost]
        public Response Post(Constraints constraint)
        {
            Response res = new Response();

            try
            {
                DTO.Constraints c = constraintBL.CreateConstraint(constraint);

                res.StatusCode = HttpStatusCode.OK;
                res.Data = c;
                res.IsError = false;

                if (c == null)
                {
                    res.Message = $"Constraint's id: {constraint.constraintId} is already exist";
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


