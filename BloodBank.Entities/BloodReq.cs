//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BloodBank.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class BloodReq
    {
        public System.Guid ReqId { get; set; }
        public string PatientName { get; set; }
        public string PatientPhoneNo { get; set; }
        public string BloodGroup { get; set; }
        public string Status { get; set; }
        public int UserUserName { get; set; }
        public System.Guid SlotSlotId { get; set; }
    
        public virtual User User { get; set; }
        public virtual Slot Slot { get; set; }
    }
}