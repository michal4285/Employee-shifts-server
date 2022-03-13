using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class EmployeeMonthShiftsBL
    {
        Entities NTT = new Entities();

        public List<DTO.EmployeeMonthShifts> getUserShifts(int userID)
        {
            var res = NTT.EmployeeMonthShifts.Where(e => e.employeeId == userID).Select(x => DTO.DTOConvertor.ConvertToDTO(x)).ToList();
            return res != null ? res : null;

        }
        public List<DTO.EmployeeMonthShifts> getShifts()
        {
            var res = NTT.EmployeeMonthShifts.Select(x => new DTO.EmployeeMonthShifts
            {
                employeeId = x.employeeId,
                title = x.title,
                startShift = x.startShift,
                endShift=x.endShift
            }).ToList();

            return res != null ? res : null;
        }
        public DTO.EmployeeMonthShifts addshift(DTO.EmployeeMonthShifts EmployeeMonthShiftsDTO)
        {
            var res = NTT.EmployeeMonthShifts.Add(DTO.DTOConvertor.ConvertToDTO(EmployeeMonthShiftsDTO));
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;
        }
    }
}
