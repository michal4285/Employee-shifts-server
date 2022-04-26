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

        public bool changeOrNot()
        {
            var day = NTT.Settings.FirstOrDefault(x => x.settingName == "DayOfChangeShifts");
            List<DTO.EmployeeMonthShifts> listShifts = NTT.EmployeeMonthShifts.Select(x => new DTO.EmployeeMonthShifts
            {
                id = x.employeeId,
                title = x.title,
                start = x.startShift,
                end = x.endShift,
                color = x.color,
            }).ToList();
            if (listShifts.Count()== 0)
                return true;
            var max = Convert.ToDateTime(listShifts[0].start);
            foreach (var item in listShifts)
            {
                var d = Convert.ToDateTime(item.start);
                if (d.Month > max.Month)
                    max = d;
            }
            //var xxx = (maxStartShift).Substring(0, 10);

            if (max.Month == DateTime.Now.Month || DateTime.Now.Day < day.settingValueInt)
            {
                return false;
            }
            return true;

        }
        public bool delete()
        {
            List<DTO.Constraints> list = NTT.Constraints.Select(x => new DTO.Constraints
            {
                constraintId = x.constraintId,
                employeeInInstitutionId = x.employeeInInstitutionId,
                dayInWeek = x.dayInWeek,
                shiftId = x.shiftId,
                dateOfCreate = x.dateOfCreate

            }).ToList();
            foreach (var item in list)
            {
                NTT.Constraints.Remove(NTT.Constraints.FirstOrDefault(x=>x.constraintId==item.constraintId));
                NTT.SaveChanges();
            }
            return true;
        }

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



                    //var res = NTT.Constraints.Select(x => new DTO.Constraints
                    //{
                    //    employeeInInstitutionId = x.employeeInInstitutionId,
                    //    dayInWeek = x.dayInWeek,
                    //    shiftId = x.shiftId,
                    //    dateOfCreate = x.dateOfCreate
                    //}).Where(x => x.employeeInInstitutionId == c.employeeInInstitutionId && x.dayInWeek == c.dayInWeek).ToArray();
                    var res = NTT.Constraints.FirstOrDefault(x => x.employeeInInstitutionId == c.employeeInInstitutionId && x.dayInWeek == c.dayInWeek);
                    var res1 = NTT.Constraints.FirstOrDefault(x => x.employeeInInstitutionId == c.employeeInInstitutionId && x.dayInWeek == c.dayInWeek && x.shiftId != res.shiftId);
                    //for (int i = 0; i < res.Length; i++)
                    //{
                    if (res.dateOfCreate > res1.dateOfCreate)
                    {

                        res1.employeeInInstitutionId = c.employeeInInstitutionId;
                        res1.dayInWeek = c.dayInWeek;
                        res1.shiftId = c.shiftId;
                        res1.dateOfCreate = DateTime.Now.AddMilliseconds(DateTime.Now.Millisecond);
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

                        res.employeeInInstitutionId = c.employeeInInstitutionId;
                        res.dayInWeek = c.dayInWeek;
                        res.shiftId = c.shiftId;
                        res.dateOfCreate = DateTime.Now.AddMilliseconds(DateTime.Now.Millisecond);
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
                    //}

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
                        dateOfCreate = x.dateOfCreate,

                    }).ToList();

                    return list1;
                }
            }

            return null;

        }

        
        public List<DTO.EmployeeMonthShifts> checkOrderShift()
        {
            

            bool flag = false;
            var numEmployeeInShift = NTT.Settings.FirstOrDefault(x => x.settingName == "NumEmployeesInShift");
            int[] arr1 = new int[7];
            int[] arr2 = new int[7];
            int[] arr3 = new int[7];
            List<DTO.Constraints>[,] mat = new List<DTO.Constraints>[7, 3];
            List<DTO.EmployeeMonthShifts>[,] mat2 = new List<DTO.EmployeeMonthShifts>[7,3];
            List<DTO.EmployeeDetail> listEmpHaveConstraint = new List<DTO.EmployeeDetail>();
            for (int i = 0; i < 7; i++)
            {
                
                for (int j = 0; j < 3; j++)
                {
                    mat[i, j] = new List<DTO.Constraints>();
                    mat2[i, j] = new List<DTO.EmployeeMonthShifts>();
                }
            }
            List<DTO.EmployeeDetail> listEmp = NTT.EmployeeDetails.Select(x => new DTO.EmployeeDetail
            {
                employeeId = x.employeeId,
                employeeFirstName = x.employeeFirstName,
                employeeLastName = x.employeeLastName,
                employeeAddress = x.employeeAddress,
                employeePhone = x.employeePhone,
                employeeEmail = x.employeeEmail,
                employeePassword = x.employeePassword
            }).ToList();

            List<DTO.Constraints> list = NTT.Constraints.Select(x => new DTO.Constraints
            {
                employeeInInstitutionId = x.employeeInInstitutionId,
                dayInWeek = x.dayInWeek,
                shiftId = x.shiftId,
                dateOfCreate = x.dateOfCreate
            }).ToList();
            foreach(var e in listEmp)
            {
                var emp = NTT.Constraints.FirstOrDefault(x => x.employeeInInstitutionId == e.employeeId && x.shiftId != 0);
                if (emp != null)
                    listEmpHaveConstraint.Add(e);
            }
            foreach (var item in list)
            {
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    for (int j = 0; j < mat.GetLength(1); j++)
                    {
                        if (item.dayInWeek == i + 1 && item.shiftId == j + 1)
                            mat[i, j].Add(item);
                    }
                }
            }

            foreach (var emp in listEmpHaveConstraint)
            {
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    flag = false;
                    var e = NTT.Constraints.FirstOrDefault(x => x.employeeInInstitutionId == emp.employeeId && x.shiftId == 0);
                    if (e == null||e!=null&&e.dayInWeek!=i+1)
                    {
                        for (int j = 0; j < mat.GetLength(1); j++)
                        {                      
                                foreach (var c in mat[i, j])
                                {
                                    if (emp.employeeId == c.employeeInInstitutionId)
                                    {
                                        flag = true;
                                        break;
                                    }

                                }
                                if (flag == false)
                                {
                                    if (j == 0)
                                    {
                                        if (arr1[i] < numEmployeeInShift.settingValueInt)
                                        {
                                            arr1[i]++;
                                            DTO.EmployeeMonthShifts c = new DTO.EmployeeMonthShifts
                                            {
                                                id = emp.employeeId,
                                                title = emp.employeeFirstName + " " + emp.employeeLastName,
                                                start = DateTime.Now.ToString(),
                                                end = DateTime.Now.ToString(),
                                            };
                                            mat2[i, j].Add(c);
                                            break;
                                        }
                                    }
                                    else if (j == 1)
                                    {
                                        if (arr2[i] < numEmployeeInShift.settingValueInt)
                                        {
                                            arr2[i]++;
                                            DTO.EmployeeMonthShifts c = new DTO.EmployeeMonthShifts
                                            {
                                                id = emp.employeeId,
                                                title = emp.employeeFirstName + " " + emp.employeeLastName,
                                                start  = DateTime.Now.ToString(),
                                                end  = DateTime.Now.ToString(),
                                            };
                                            mat2[i, j].Add(c);
                                            break;
                                        }

                                    }
                                    else
                                    {
                                        if (arr3[i] < numEmployeeInShift.settingValueInt)
                                        {
                                            arr3[i]++;
                                            DTO.EmployeeMonthShifts c = new DTO.EmployeeMonthShifts
                                            {
                                                id = emp.employeeId,
                                                title = emp.employeeFirstName + " " + emp.employeeLastName,
                                                start  = DateTime.Now.ToString(),
                                                end= DateTime.Now.ToString(),
                                            };
                                            mat2[i, j].Add(c);
                                        }
                                    }
                                }
                        }
                    }

                }
                listEmp.Remove(emp);
            }
            foreach (var emp in listEmp)
            {
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    flag = false;
                    var e = NTT.Constraints.FirstOrDefault(x => x.employeeInInstitutionId == emp.employeeId && x.shiftId == 0);
                    if (e==null||e != null && e.dayInWeek != i + 1)
                    {
                        for (int j = 0; j < mat.GetLength(1); j++)
                        {
                                foreach (var c in mat[i, j])
                                {
                                    if (emp.employeeId == c.employeeInInstitutionId)
                                    {
                                        flag = true;
                                        break;
                                    }

                                }
                                if (flag == false)
                                {
                                    if (j == 0)
                                    {
                                        if (arr1[i] < numEmployeeInShift.settingValueInt)
                                        {
                                            arr1[i]++;
                                            DTO.EmployeeMonthShifts c = new DTO.EmployeeMonthShifts
                                            {
                                                id = emp.employeeId,
                                                title = emp.employeeFirstName + " " + emp.employeeLastName,
                                                start  = DateTime.Now.ToString(),
                                                end  = DateTime.Now.ToString(),
                                            };
                                            mat2[i, j].Add(c);
                                            break;
                                        }
                                    }
                                    else if (j == 1)
                                    {
                                        if (arr2[i] < numEmployeeInShift.settingValueInt)
                                        {
                                            arr2[i]++;
                                            DTO.EmployeeMonthShifts c = new DTO.EmployeeMonthShifts
                                            {
                                                id = emp.employeeId,
                                                title = emp.employeeFirstName + " " + emp.employeeLastName,
                                                start  = DateTime.Now.ToString(),
                                                end  = DateTime.Now.ToString(),
                                            };
                                            mat2[i, j].Add(c);
                                            break;
                                        }

                                    }
                                    else
                                    {
                                        if (arr3[i] < numEmployeeInShift.settingValueInt)
                                        {
                                            arr3[i]++;
                                            DTO.EmployeeMonthShifts c = new DTO.EmployeeMonthShifts
                                            {
                                                id= emp.employeeId,
                                                title = emp.employeeFirstName + " " + emp.employeeLastName,
                                                start  = DateTime.Now.ToString(),
                                                end  = DateTime.Now.ToString(),
                                            };
                                            mat2[i, j].Add(c);
                                        }
                                    }
                                }
                            
                        }
                    }

                }
            }
            //for (int i = 0; i < mat2.GetLongLength(0); i++)
            //{
            //    for(int j=0;j<mat2.GetLongLength(1);j++)
            //    {
            //        foreach(var em in mat2[i,j])
            //        {                                        
            //            var con= DTO.DTOConvertor.ConvertToDTO(em);
            //            NTT.EmployeeMonthShifts.Add(con);
            //            NTT.SaveChanges();
            //        }


            //    }
            //}
            //List<DTO.EmployeeMonthShifts> g = NTT.EmployeeMonthShifts.Select(x => new DTO.EmployeeMonthShifts
            //{
            //    id = x.employeeId,
            //    title = x.title,
            //    start = x.startShift,
            //    end= x.endShift,
            //}).ToList();
            //foreach(var item in g)
            //{
                
            //    NTT.EmployeeMonthShifts.Remove(NTT.EmployeeMonthShifts.FirstOrDefault(x=>x.employeeId==item.id&&item.start==x.startShift&&x.endShift==item.end));
            //    NTT.SaveChanges();
            //}
            for (int i = 1; i <= (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)); i++)
            {

                var y = (int)(new DateTime(DateTime.Now.Year, DateTime.Now.Month, i)).DayOfWeek + 1;
                var x = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, i)).ToString(("yyyy-MM-dd'T'HH:mm:ss"));
                foreach (var item in mat2[y - 1, 0])
                {
                    item.start = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, i,08,00,00)).ToString(("yyyy-MM-dd'T'HH:mm:ss"));
                    item.end = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, i,16,00,00)).ToString(("yyyy-MM-dd'T'HH:mm:ss"));
                    item.color = "rgb(165, 223, 172)";
                    var con = DTO.DTOConvertor.ConvertToDTO(item);
                    NTT.EmployeeMonthShifts.Add(con);
                    NTT.SaveChanges();

                }
                foreach (var item in mat2[y - 1, 1])
                {
                    item.start = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, i,16,00,00)).ToString(("yyyy-MM-dd'T'HH:mm:ss"));
                    item.end = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, i,23,59,59)).ToString(("yyyy-MM-dd'T'HH:mm:ss"));
                    item.color = "rgb(197, 106, 152)";
                    var con = DTO.DTOConvertor.ConvertToDTO(item);
                    NTT.EmployeeMonthShifts.Add(con);
                    NTT.SaveChanges();

                }
                foreach (var item in mat2[y - 1, 2])
                {
                    item.start = (new DateTime(DateTime.Now.Year, DateTime.Now.Month,i,00,00,00)).ToString(("yyyy-MM-dd'T'HH:mm:ss"));
                    item.end = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, i,08,00,00)).ToString(("yyyy-MM-dd'T'HH:mm:ss"));
                    item.color = "rgb(163, 168, 235)";
                    var con = DTO.DTOConvertor.ConvertToDTO(item);
                    NTT.EmployeeMonthShifts.Add(con);
                    NTT.SaveChanges();

                }


            }

            List<DTO.EmployeeMonthShifts> listShifts = NTT.EmployeeMonthShifts.Select(x => new DTO.EmployeeMonthShifts
            {
                id = x.employeeId,
                title = x.title,
                start = x.startShift,
                end = x.endShift,
                color=x.color,
            }).ToList();

            return listShifts;
        }
    }
}







