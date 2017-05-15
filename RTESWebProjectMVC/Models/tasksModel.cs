using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTESWebProjectMVC.Models
{
    public class tasksModel
    {

        public int reportId { get; set; }
        public String location { get; set; }
        public String towing_destination { get; set; }
        public String familyName { get; set; }
        public String name { get; set; }
        public String userPhoneNumber { get; set; }
        public String carCategory { get; set; }
        public String carModel { get; set; }
        public int licensePlate { get; set; }


}
}