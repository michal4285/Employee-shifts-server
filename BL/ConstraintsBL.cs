using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Converters;

namespace BL
{
    public class ConstraintsBL
    {
        Entities NTT = new Entities();
        public DTO.Constraints getConstraint(int id)
        {
            var res = NTT.Constraints.FirstOrDefault(x => x.constraintId == id);
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;

        }
        public List<DTO.Constraints> getConstraintEmployee(int id)
        {
            var res = NTT.Constraints.Select(x => new DTO.Constraints
            {
                employeeInInstitutionId = x.employeeInInstitutionId,
                dayInWeek = x.dayInWeek,
                shiftId = x.shiftId,
                dateOfCreate = x.dateOfCreate
            }).Where(x => x.employeeInInstitutionId == id).ToList();
            return res != null ? res : null;
        }
        public List<DTO.Constraints> GetAllConstraints()
        {
            var res = NTT.Constraints.Select(x => new DTO.Constraints
            {
                employeeInInstitutionId = x.employeeInInstitutionId,
                dayInWeek = x.dayInWeek,
                shiftId = x.shiftId,
                dateOfCreate = x.dateOfCreate
            }).ToList();

            return res != null ? res : null;
        }
        public DTO.Constraints CreateConstraint(DTO.Constraints c)
        {
            var constraint = NTT.Constraints.FirstOrDefault(e => e.constraintId == c.constraintId);

            Constraints res = constraint == null ? NTT.Constraints.Add(DTO.DTOConvertor.ConvertToDTO(c)) : null;
            NTT.SaveChanges();
            return res != null ? DTO.DTOConvertor.ConvertToDTO(res) : null;
        }
        public DTO.Constraints checkConstraint(DTO.Constraints c)
        {
            var shiftInDay = NTT.Constraints.Count(x => x.employeeInInstitutionId == c.employeeInInstitutionId && x.dayInWeek == c.dayInWeek && x.shiftId != 0);
            var employee = NTT.Constraints.FirstOrDefault(e => e.employeeInInstitutionId == c.employeeInInstitutionId && e.shiftId == 0);
            var countConstraint = NTT.Constraints.Count(e => e.dayInWeek == c.dayInWeek && e.shiftId == 0);
            var settingNumDays = NTT.Settings.FirstOrDefault(x => x.settingName == "NumMissingEmployeesInDay");
            if (countConstraint < settingNumDays.settingValueInt && employee == null && shiftInDay > 0)
            {
                //var res = new DTO.Constraints
                //{
                //    employeeInInstitutionId = c.employeeInInstitutionId,
                //    dayInWeek = c.dayInWeek,
                //    shiftId = c.shiftId,
                //    dateOfCreate = c.dateOfCreate
                //};
                //Constraints r1 = DTO.DTOConvertor.ConvertToDTO(res);
                if (shiftInDay > 1)
                {
                    NTT.Constraints.Remove(NTT.Constraints.FirstOrDefault(x => x.employeeInInstitutionId == c.employeeInInstitutionId && x.dayInWeek == c.dayInWeek && x.shiftId != 0));
                    NTT.SaveChanges();
                    NTT.Constraints.Remove(NTT.Constraints.FirstOrDefault(x => x.employeeInInstitutionId == c.employeeInInstitutionId && x.dayInWeek == c.dayInWeek && x.shiftId != 0));
                    NTT.SaveChanges();
                    DAL.Constraints con = DTO.DTOConvertor.ConvertToDTO(c);
                    Constraints r = NTT.Constraints.Add(con);
                    NTT.SaveChanges();
                    return r != null ? DTO.DTOConvertor.ConvertToDTO(r) : null;
                }
                else
                {
                    NTT.Constraints.Remove(NTT.Constraints.FirstOrDefault(x => x.employeeInInstitutionId == c.employeeInInstitutionId && x.dayInWeek == c.dayInWeek && x.shiftId != 0));
                    NTT.SaveChanges();
                    DAL.Constraints con = DTO.DTOConvertor.ConvertToDTO(c);
                    Constraints r = NTT.Constraints.Add(con);
                    NTT.SaveChanges();
                    return r != null ? DTO.DTOConvertor.ConvertToDTO(r) : null;

                }

            }
            else if (countConstraint < settingNumDays.settingValueInt && employee == null && shiftInDay < 1)
            {
                DAL.Constraints con = DTO.DTOConvertor.ConvertToDTO(c);
                Constraints r = NTT.Constraints.Add(con);
                NTT.SaveChanges();
                return r != null ? DTO.DTOConvertor.ConvertToDTO(r) : null;

            }
            else if (countConstraint < settingNumDays.settingValueInt && employee != null && shiftInDay > 0)
            {
                if (shiftInDay > 1)
                {
                    NTT.Constraints.Remove(NTT.Constraints.FirstOrDefault(x => x.employeeInInstitutionId == c.employeeInInstitutionId && x.dayInWeek == c.dayInWeek && x.shiftId != 0));
                    NTT.SaveChanges();
                    NTT.Constraints.Remove(NTT.Constraints.FirstOrDefault(x => x.employeeInInstitutionId == c.employeeInInstitutionId && x.dayInWeek == c.dayInWeek && x.shiftId != 0));
                    NTT.SaveChanges();
                    NTT.Constraints.Remove(NTT.Constraints.FirstOrDefault(x => x.employeeInInstitutionId == c.employeeInInstitutionId && x.shiftId == 0));
                    NTT.SaveChanges();
                    NTT.Constraints.Add(DTO.DTOConvertor.ConvertToDTO(c));
                    NTT.SaveChanges();
                    return c;
                }
                else
                {
                    NTT.Constraints.Remove(NTT.Constraints.FirstOrDefault(x => x.employeeInInstitutionId == c.employeeInInstitutionId && x.dayInWeek == c.dayInWeek && x.shiftId != 0));
                    NTT.SaveChanges();
                    NTT.Constraints.Remove(NTT.Constraints.FirstOrDefault(x => x.employeeInInstitutionId == c.employeeInInstitutionId && x.dayInWeek == c.dayInWeek && x.shiftId == 0));
                    NTT.SaveChanges();
                    NTT.Constraints.Add(DTO.DTOConvertor.ConvertToDTO(c));
                    NTT.SaveChanges();
                    return c;
                }

            }
            else if (countConstraint < settingNumDays.settingValueInt && employee != null)
            {
                NTT.Constraints.Remove(NTT.Constraints.FirstOrDefault(x => x.employeeInInstitutionId == c.employeeInInstitutionId && x.shiftId == 0));
                NTT.SaveChanges();
                NTT.Constraints.Add(DTO.DTOConvertor.ConvertToDTO(c));
                NTT.SaveChanges();
                return c;
            }
            return null;

        }
        public List<DTO.Constraints> checkConstraintShift(DTO.Constraints c)
        {
            var holiday = NTT.Constraints.FirstOrDefault(x => x.employeeInInstitutionId == c.employeeInInstitutionId && x.shiftId == 0 && x.dayInWeek == c.dayInWeek);
            var settingNumShifts = NTT.Settings.FirstOrDefault(s => s.settingName == "NumMissingEmployeesInShift");
            var numEmployees = NTT.Constraints.Count(e => e.dayInWeek == c.dayInWeek && e.shiftId == c.shiftId);
            if (numEmployees < settingNumShifts.settingValueInt && holiday == null)
            {
                var numShiftEm = NTT.Constraints.Count(e => e.employeeInInstitutionId == c.employeeInInstitutionId && e.dayInWeek == c.dayInWeek);
                if (numShiftEm < 2)
                {
                    NTT.Constraints.Add(DTO.DTOConvertor.ConvertToDTO(c));
                    NTT.SaveChanges();
                    var r = NTT.Constraints.Select(x => new DTO.Constraints
                    {
                        employeeInInstitutionId = x.employeeInInstitutionId,
                        dayInWeek = x.dayInWeek,
                        shiftId = x.shiftId,
                        dateOfCreate = x.dateOfCreate
                    }).Where(x => x.employeeInInstitutionId == c.employeeInInstitutionId && x.dayInWeek == c.dayInWeek).ToList();
                    return r;
                }
                else
                {
                    var res = NTT.Constraints.Select(x => new DTO.Constraints
                    {
                        employeeInInstitutionId = x.employeeInInstitutionId,
                        dayInWeek = x.dayInWeek,
                        shiftId = x.shiftId,
                        dateOfCreate = x.dateOfCreate
                    }).Where(x => x.employeeInInstitutionId == c.employeeInInstitutionId && x.dayInWeek == c.dayInWeek).ToArray();
                    for (int i = 0; i < res.Length; i++)
                    {
                        if (res[i].dateOfCreate > res[i + 1].dateOfCreate)
                        {
                            res[i + 1].constraintId = c.constraintId;
                            res[i + 1].employeeInInstitutionId = c.employeeInInstitutionId;
                            res[i + 1].dayInWeek = c.dayInWeek;
                            res[i + 1].shiftId = c.shiftId;
                            res[i + 1].dateOfCreate = c.dateOfCreate;
                            NTT.SaveChanges();
                            return res.ToList();

                        }
                        else
                        {
                            res[i].constraintId = c.constraintId;
                            res[i].employeeInInstitutionId = c.employeeInInstitutionId;
                            res[i].dayInWeek = c.dayInWeek;
                            res[i].shiftId = c.shiftId;
                            res[i].dateOfCreate = c.dateOfCreate;
                            NTT.SaveChanges();
                            return res.ToList();
                        }
                    }

                }
                return null;

            }
            else
            {
                return null;
            }

        }
        public List<DTO.Constraints> checkHoliday()
        {
            int[] arr = new int[7];
            for (int i = 0; i < 7; i++)
            {
                arr[i] = NTT.Constraints.Count(x => x.dayInWeek == (i + 1) && x.shiftId == 0);

            }
            var settingNumDays = NTT.Settings.FirstOrDefault(x => x.settingName == "NumMissingEmployeesInDay");
            List<DTO.EmployeeDetail> list = NTT.EmployeeDetails.Select(x => new DTO.EmployeeDetail
            {
                employeeId = x.employeeId,
                employeeFirstName = x.employeeFirstName,
                employeeLastName = x.employeeLastName,
                employeeAddress = x.employeeAddress,
                employeePhone = x.employeePhone,
                employeeEmail = x.employeeEmail,
                employeePassword = x.employeePassword
            }).ToList();
            foreach (var item in list)
            {
                var emp = NTT.Constraints.FirstOrDefault(x => x.employeeInInstitutionId == item.employeeId && x.shiftId == 0);
                if (emp == null)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] < settingNumDays.settingValueInt)
                        {
                            arr[i]++;
                            DTO.Constraints c = new DTO.Constraints
                            {
                                employeeInInstitutionId = item.employeeId,
                                dayInWeek = i + 1,
                                shiftId = 0,
                                dateOfCreate = DateTime.Now
                            };
                            DAL.Constraints con = DTO.DTOConvertor.ConvertToDTO(c);
                            NTT.Constraints.Add(con);
                            NTT.SaveChanges();
                            break;
                        }

                    }

                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != settingNumDays.settingValueInt)
                    return null;
                else
                {
                    List<DTO.Constraints> list1 = NTT.Constraints.Select(x => new DTO.Constraints
                    {
                        employeeInInstitutionId = x.employeeInInstitutionId,
                        dayInWeek = x.dayInWeek,
                        shiftId = x.shiftId,
                        dateOfCreate = x.dateOfCreate
                    }).ToList();
                    return list1;
                }
            }
            return null;

        }
    }
}







