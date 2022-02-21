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
    public class SettingsController : ApiController
    {
        SettingsBL settingsBL = new SettingsBL();

        //GET api/Settings/id

        [HttpGet]

        public Response GetSetting(int settingId)
        {
            Response res = new Response();
            try
            {
                DTO.settings setting = settingsBL.getSetting(settingId);
                res.StatusCode = HttpStatusCode.OK;
                res.Data = setting;
                res.IsError = false;

                if (setting == null)
                    res.Message = $"you have a mistake,setting id:{settingId} isn't exist";

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
        public Response GetSettings()
        {
            Response res = new Response();

            try
            {
                List<DTO.settings> setting = settingsBL.getSettings();

                res.StatusCode = HttpStatusCode.OK;
                res.Data = setting;
                res.IsError = setting == null;

                if (setting == null)
                {
                    res.Message = "There are no settings";
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
        // POST api/Settings
        public Response addSetting(settings setting)
        {
            Response res = new Response();

            try
            {
                DTO.settings settings = settingsBL.addsetting(setting);

                res.StatusCode = HttpStatusCode.OK;
                res.Data = settings;
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
        [HttpPost]
        // PUT: api/Employee/5
        public Response Update(settings settings)
        {
            Response res = new Response();

            try
            {
                DTO.settings setting = settingsBL.update(settings);

                res.StatusCode = HttpStatusCode.OK;
                res.Data = setting;
                res.IsError = false;

                if (setting == null)
                {
                    res.Message = $"employee's name: {setting.settingName} is not succeed to update";
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