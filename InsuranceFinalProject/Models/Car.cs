//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InsuranceFinalProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public int CarId { get; set; }
        public string ModeofUse { get; set; }
        public int CarReg { get; set; }
        public int CarValue { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual User User { get; set; }
    }
}
