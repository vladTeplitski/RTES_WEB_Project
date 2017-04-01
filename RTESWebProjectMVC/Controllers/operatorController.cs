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

            string userName;
            int userId;

            using (var db = new Models.rtesEntities1())
            {
                userName = Session["user"].ToString();  //read the user name
                userId = (int)(Session["uid"]);    //convert session to int - read the id



                //clients list for dropdown - from DB


                var clients = db.abstract_user.Where(i => i.role == "Client").ToList();

                ViewBag.dropListUsers = clients;


            }




            return View();
        }
    }
}