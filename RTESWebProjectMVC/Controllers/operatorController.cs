using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTESWebProjectMVC.Controllers
{
    public class operatorController : baseController
    {
        // GET: operator
        public ActionResult operatorHome()
        {
            base.initFunc();  //init the base functions - user CP
            return View();
        }
    }
}