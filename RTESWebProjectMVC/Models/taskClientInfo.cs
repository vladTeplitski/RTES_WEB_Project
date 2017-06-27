using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTESWebProjectMVC.Models
{
    public class taskClientInfo
    {
        public int clientId { get; set; }
        public String name { get; set; }
        public String carModel { get; set; }
        public String location { get; set; }
        public String phone { get; set; }
        public String category { get; set; }
        public int licensePlate { get; set; }

        public String destination { get; set; }

    }
}