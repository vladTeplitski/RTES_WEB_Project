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
    
    public partial class emergencyReports
    {
        public int reportID { get; set; }
        public int clientAbstractUserId { get; set; }
        public Nullable<int> caseCaseId { get; set; }
        public string date { get; set; }
        public string hour { get; set; }
        public string location { get; set; }
        public string towing_destination { get; set; }
        public string accident_witness_name { get; set; }
        public string accident_witness_phone { get; set; }
        public string comments { get; set; }
        public bool callForTowing { get; set; }
        public Nullable<int> status { get; set; }
        public string OperatorComment { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string latDest { get; set; }
        public string lngDest { get; set; }
    }
}