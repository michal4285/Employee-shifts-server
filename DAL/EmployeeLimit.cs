//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeLimit
    {
        public int restrictionId { get; set; }
        public Nullable<int> employeeInInstitutionId { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> shiftInInstitutionId { get; set; }
        public Nullable<int> substituteEmployeeId { get; set; }
    
        public virtual ShiftInstitution ShiftInstitution { get; set; }
    }
}
