using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTESWebProjectMVC.Models
{
    public class truckDriverList
    {
        public int driverId { get; set; }
        public String lan { get; set; }
        public String lng { get; set; }
        public int tasksCount { get; set; }
        public int distance { get; set; }
        public int reportId { get; set; }
        public string[] tasksLat { get; set; }
        public string[] tasksLng { get; set; }


    }
}