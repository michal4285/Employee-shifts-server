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
        #region Constraints
        public static DTO.Constraints ConvertToDTO(DAL.Constraints constraint)
        {
            return new DTO.Constraints()
            {
                constraintId = constraint.constraintId,
                employeeInInstitutionId = constraint.employeeInInstitutionId,
                dayInWeek = constraint.dayInWeek,
                shiftId = constraint.shiftId,
                dateOfCreate = constraint.dateOfCreate
            };
        }
        public static DAL.Constraints ConvertToDTO(DTO.Constraints constraint)
        {
            return new DAL.Constraints()
            {
                constraintId = constraint.constraintId,
                employeeInInstitutionId = constraint.employeeInInstitutionId,
                dayInWeek = constraint.dayInWeek,
                shiftId = constraint.shiftId,
                dateOfCreate = DateTime.Now.AddMilliseconds(DateTime.Now.Millisecond)
            };
        }
        #endregion
        #region EmployeeInInstitution
        public static DTO.EmployeeInInstitution ConvertToDTO(DAL.EmployeeInInstitution employeeInInstitution)
        {
            return new DTO.EmployeeInInstitution()
            {
                employeeInInstitutionId = employeeInInstitution.employeeInInstitutionId,
                employeerId = employeeInInstitution.employeerId,
                institutionId = employeeInInstitution.institutionId,
                fieldOfWorkId = employeeInInstitution.fieldOfWorkId,
                status = employeeInInstitution.status,
                shiftType = employeeInInstitution.shiftType,
            };
        }
        public static DAL.EmployeeInInstitution ConvertToDTO(DTO.EmployeeInInstitution employeeInInstitution)
        {
            return new DAL.EmployeeInInstitution()
            {
                employeeInInstitutionId = employeeInInstitution.employeeInInstitutionId,
                employeerId = employeeInInstitution.employeerId,
                institutionId = employeeInInstitution.institutionId,
                fieldOfWorkId = employeeInInstitution.fieldOfWorkId,
                status = employeeInInstitution.status,
                shiftType = employeeInInstitution.shiftType,
            };
        }
        #endregion
        #region EmployeeLimit
        public static DTO.EmployeeLimit ConvertToDTO(DAL.EmployeeLimit employeeLimit)
        {
            return new DTO.EmployeeLimit()
            {

                restrictionId = employeeLimit.restrictionId,
                employeeInInstitutionId = employeeLimit.employeeInInstitutionId,
                date = employeeLimit.date,
                shiftInInstitutionId = employeeLimit.shiftInInstitutionId,
                substituteEmployeeId = employeeLimit.substituteEmployeeId,
            };
        }
        public static DAL.EmployeeLimit ConvertToDTO(DTO.EmployeeLimit employeeLimit)
        {
            return new DAL.EmployeeLimit()
            {

                restrictionId = employeeLimit.restrictionId,
                employeeInInstitutionId = employeeLimit.employeeInInstitutionId,
                date = employeeLimit.date,
                shiftInInstitutionId = employeeLimit.shiftInInstitutionId,
                substituteEmployeeId = employeeLimit.substituteEmployeeId,
            };
        }
        #endregion
        #region FieldOfWorkInInstitution
        public static DTO.FieldOfWorkInInstitution ConvertToDTO(DAL.FieldOfWorkInInstitution fieldOfWorkInInstitution)
        {
            return new DTO.FieldOfWorkInInstitution()
            {
                fieldOfWorkId = fieldOfWorkInInstitution.fieldOfWorkId,
                institutionId = fieldOfWorkInInstitution.institutionId,
                fieldOfWorkName = fieldOfWorkInInstitution.fieldOfWorkName,
                numOfFullTimeShift = fieldOfWorkInInstitution.numOfFullTimeShift,
                numOfPartTimeShift = fieldOfWorkInInstitution.numOfPartTimeShift,
                numOfEmployeesInWeeklyShift = fieldOfWorkInInstitution.numOfEmployeesInWeeklyShift,
            };
        }
        public static DAL.FieldOfWorkInInstitution ConvertToDTO(DTO.FieldOfWorkInInstitution fieldOfWorkInInstitution)
        {
            return new DAL.FieldOfWorkInInstitution()
            {
                fieldOfWorkId = fieldOfWorkInInstitution.fieldOfWorkId,
                institutionId = fieldOfWorkInInstitution.institutionId,
                fieldOfWorkName = fieldOfWorkInInstitution.fieldOfWorkName,
                numOfFullTimeShift = fieldOfWorkInInstitution.numOfFullTimeShift,
                numOfPartTimeShift = fieldOfWorkInInstitution.numOfPartTimeShift,
                numOfEmployeesInWeeklyShift = fieldOfWorkInInstitution.numOfEmployeesInWeeklyShift,
            };
        }
        #endregion
        #region InstitutionDetails
        public static DTO.InstitutionDetails ConvertToDTO(DAL.InstitutionDtails institutionDtails)
        {
            return new DTO.InstitutionDetails()
            {
                institutionId = institutionDtails.institutionId,
                institutionName = institutionDtails.institutionName,
                institutionAddress = institutionDtails.institutionAddress,
                institutionEmail = institutionDtails.institutionEmail,
                institutionPhone = institutionDtails.institutionPhone,
                institutionManagerId = institutionDtails.institutionManagerId,
                numOfShift = institutionDtails.numOfShift,

            };
        }
        public static DAL.InstitutionDtails ConvertToDTO(DTO.InstitutionDetails institutionDtails)
        {
            return new DAL.InstitutionDtails()
            {
                institutionId = institutionDtails.institutionId,
                institutionName = institutionDtails.institutionName,
                institutionAddress = institutionDtails.institutionAddress,
                institutionEmail = institutionDtails.institutionEmail,
                institutionPhone = institutionDtails.institutionPhone,
                institutionManagerId = institutionDtails.institutionManagerId,
                numOfShift = institutionDtails.numOfShift,
            };
        }
        #endregion
        #region settings
        public static DTO.settings ConvertToDTO(DAL.Settings settings)
        {
            return new DTO.settings()
            {
                settingId = settings.settingId,
                institutionId = settings.institutionId,
                settingName = settings.settingName,
                settingValueInt = settings.settingValueInt,
                settingValueDate = settings.settingValueDate,
                settingValueString = settings.settingValueString

            };
        }
        public static DAL.Settings ConvertToDTO(DTO.settings settings)
        {
            return new DAL.Settings()
            {
                settingId = settings.settingId,
                institutionId = settings.institutionId,
                settingName = settings.settingName,
                settingValueInt = settings.settingValueInt,
                settingValueDate = settings.settingValueDate,
                settingValueString = settings.settingValueString
            };
        }

        #endregion
        #region EmployeeMonthShifts
        public static DTO.EmployeeMonthShifts ConvertToDTO(DAL.EmployeeMonthShifts employeeMonthShifts)
        {
            return new DTO.EmployeeMonthShifts()
            {
                //employeeShiftId = employeeMonthShifts.employeeShiftId,
                id = employeeMonthShifts.employeeId,
                title=employeeMonthShifts.title,
                start=employeeMonthShifts.startShift,
                end=employeeMonthShifts.endShift,
                color= employeeMonthShifts.color
            };

        }
        public static DAL.EmployeeMonthShifts ConvertToDTO(DTO.EmployeeMonthShifts employeeMonthShifts)
        {
            return new DAL.EmployeeMonthShifts()
            {
                employeeId = employeeMonthShifts.id,
                title = employeeMonthShifts.title,
                startShift = employeeMonthShifts.start,
                endShift = employeeMonthShifts.end,
                color= employeeMonthShifts.color
            };

        }
        #endregion
    }
}
