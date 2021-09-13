using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public static class DTOConvertor
    {
        #region EmployeeDetail
        public static DTO.EmployeeDetail ConvertToDTO(DAL.EmployeeDetails employeeDetails)
        {
            return new DTO.EmployeeDetail()
            {
                employeeId = employeeDetails.employeeId,
                employeeAddress = employeeDetails.employeeAddress,
                employeeEmail = employeeDetails.employeeEmail,
                employeePassword = employeeDetails.employeePassword,
                employeePhone = employeeDetails.employeePhone,
                employeeFirstName = employeeDetails.employeeFirstName,
                employeeLastName = employeeDetails.employeeLastName
            };
        }


        public static DAL.EmployeeDetails ConvertToDTO(DTO.EmployeeDetail employeeDetails)
        {
            return new DAL.EmployeeDetails()
            {
                employeeId = employeeDetails.employeeId,
                employeeAddress = employeeDetails.employeeAddress,
                employeeEmail = employeeDetails.employeeEmail,
                employeePassword = employeeDetails.employeePassword,
                employeePhone = employeeDetails.employeePhone,
                employeeFirstName = employeeDetails.employeeFirstName,
                employeeLastName = employeeDetails.employeeLastName
            };
        }

        #endregion
        #region Dialogue 
        public static DTO.Dialogue ConvertToDTO(DAL.Dialogue dialogue)
        {
            return new DTO.Dialogue()
            {
                dialogueId = dialogue.dialogueId,
                employeeInInstitutionId = dialogue.employeeInInstitutionId,
                status = dialogue.status,
                text = dialogue.text,
                date = dialogue.date
            };
        }
        public static DAL.Dialogue ConvertToDTO(DTO.Dialogue dialogue)
        {
            return new DAL.Dialogue()
            {
                dialogueId = dialogue.dialogueId,
                employeeInInstitutionId = dialogue.employeeInInstitutionId,
                status = dialogue.status,
                text = dialogue.text,
                date = dialogue.date
            };
        }
        #endregion
        #region EmployeeShifts
        public static DTO.EmployeeShiftsDTO ConvertToDTO(DAL.EmployeeShifts employeeShifts)
        {
            return new DTO.EmployeeShiftsDTO()
            {
                employeeShiftId = employeeShifts.employeeShiftId,
                employeeInInstitutionId = employeeShifts.employeeInInstitutionId,
                Date = employeeShifts.Date,
                ShiftId = employeeShifts.ShiftId
            };

        }
        public static DAL.EmployeeShifts ConvertToDTO(DTO.EmployeeShiftsDTO employeeShifts)
        {
            return new DAL.EmployeeShifts()
            {
                employeeShiftId = employeeShifts.employeeShiftId,
                employeeInInstitutionId = employeeShifts.employeeInInstitutionId,
                Date = employeeShifts.Date,
                ShiftId = employeeShifts.ShiftId
            };

        }
        #endregion
        #region ShiftInstitution
        public static DTO.ShiftInstitutionDTO ConvertToDTO(DAL.ShiftInstitution ShiftInstitution)
        {
            return new ShiftInstitutionDTO()
            {
                shiftInstitutionId = ShiftInstitution.shiftInstitutionId,
                institutionId = ShiftInstitution.institutionId,
                shiftNum = ShiftInstitution.shiftNum,
                shiftDescription = ShiftInstitution.shiftDescription,
                startTime = ShiftInstitution.startTime,
                EndTime = ShiftInstitution.EndTime
            };
        }
        public static DAL.ShiftInstitution ConvertToDTO(ShiftInstitutionDTO ShiftInstitution)
        {
            return new DAL.ShiftInstitution()
            {
                shiftInstitutionId = ShiftInstitution.shiftInstitutionId,
                institutionId = ShiftInstitution.institutionId,
                shiftNum = ShiftInstitution.shiftNum,
                shiftDescription = ShiftInstitution.shiftDescription,
                startTime = ShiftInstitution.startTime,
                EndTime = ShiftInstitution.EndTime
            };
        }
        #endregion
    }
}
