//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RTESWebProjectMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class client
    {
        public int abstractUserId { get; set; }
        public string insuranceCompanyName { get; set; }
        public Nullable<int> licensePlate { get; set; }
        public string carCategory { get; set; }
        public string carModel { get; set; }
        public string originalTowingDestination { get; set; }
        public Nullable<int> insurancePolicyNum { get; set; }
        public Nullable<int> clientDrivingLicenseNumber { get; set; }
        public string policyEndDate { get; set; }
        public string updates { get; set; }
        public Nullable<int> emergencyReportId { get; set; }
        public string carOwnerName { get; set; }
        public Nullable<int> carOwnerId { get; set; }
        public Nullable<int> carLicenseNumber { get; set; }
        public string insuranceAgentName { get; set; }
        public Nullable<int> insuranceAgentPhoneNum { get; set; }
        public string carManufactureYear { get; set; }
    
        public virtual client client1 { get; set; }
        public virtual client client2 { get; set; }
    }
}
