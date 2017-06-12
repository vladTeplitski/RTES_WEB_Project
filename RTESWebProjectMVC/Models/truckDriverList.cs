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
        public string[] reportId { get; set; }
        public string[] tasksLat { get; set; }
        public string[] tasksLng { get; set; }
        public string[] tasksLatDest { get; set; }
        public string[] tasksLngDest { get; set; }
        public int cargo { get; set; }


    }
}