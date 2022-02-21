using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Converters;

namespace BL
{
    public class SettingsBL
    {
        Entities NTT = new Entities();


        public DTO.settings getSetting(int settingId)
        {
            var res = NTT.Settings.FirstOrDefault(x => x.settingId == settingId);
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;
        }

        public List<DTO.settings> getSettings()
        {
            var res = NTT.Settings.Select(x => new DTO.settings
            {
                settingId = x.settingId,
                institutionId = x.institutionId,
                settingName = x.settingName,
                settingValueInt = x.settingValueInt,
                settingValueDate = x.settingValueDate,
                settingValueString = x.settingValueString
            }).ToList();

            return res != null ? res : null;
        }
        public DTO.settings addsetting(DTO.settings setting)
        {
            var res = NTT.Settings.Add(DTO.DTOConvertor.ConvertToDTO(setting));
            NTT.SaveChanges();
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;
        }
        public DTO.settings update(DTO.settings setting)
        {
            Settings settings = NTT.Settings.FirstOrDefault(e => e.settingName == setting.settingName && e.institutionId == setting.institutionId);

            if (settings != null)
            {
                settings.institutionId = setting.institutionId;
                settings.settingName = setting.settingName;
                settings.settingValueInt = setting.settingValueInt;
                settings.settingValueString = setting.settingValueString;
                settings.settingValueDate = setting.settingValueDate;
                NTT.SaveChanges();
                return setting;
            }

            return null;
        }
    }
}
