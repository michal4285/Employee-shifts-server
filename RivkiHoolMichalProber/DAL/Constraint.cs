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
    
    public partial class Constraint
    {
        public int constraintId { get; set; }
        public Nullable<int> employeeInInstitutionId { get; set; }
        public Nullable<System.DateTime> year { get; set; }
        public Nullable<System.DateTime> month { get; set; }
        public Nullable<System.DateTime> day { get; set; }
        public Nullable<int> shiftNum { get; set; }
    
        public virtual EmployeeInInstitution EmployeeInInstitution { get; set; }
    }
}
