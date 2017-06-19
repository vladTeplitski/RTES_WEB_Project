using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTESWebProjectMVC.Models
{
    public class tasksOrder
    {
        public int priority1 { get; set; }
        public int priority2 { get; set; }
        public int priority3 { get; set; }
        public int priority4 { get; set; }
        public int priority5 { get; set; }
        public int priority6 { get; set; }

        public String priority1Role { get; set; }
        public String priority2Role { get; set; }
        public String priority3Role { get; set; }
        public String priority4Role { get; set; }
        public String priority5Role { get; set; }
        public String priority6Role { get; set; }

        public String location1 { get; set; }
        public String location2 { get; set; }
        public String location3 { get; set; }
        public String location4 { get; set; }
        public String location5 { get; set; }
        public String location6 { get; set; }

    }
}