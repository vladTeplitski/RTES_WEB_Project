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
    
    public partial class @case
    {
        public int caseId { get; set; }
        public Nullable<int> caseAbstractUserId { get; set; }
        public string operatorComments { get; set; }
        public Nullable<byte> statusCase { get; set; }
        public string creation_date { get; set; }
        public string creation_time { get; set; }
        public Nullable<byte> needsTowingService { get; set; }
    }
}
