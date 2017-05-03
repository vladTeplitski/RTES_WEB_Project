using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTESWebProjectMVC.Controllers
{
    public class appraiserController : baseController
    {
        // GET: appraiser
        public ActionResult appraiserHome()
        {
            string userName;
            int userId;

            if (Session["user"] != null)  //if logged in user
            {
                var db = new Models.rtesEntities1();
                userName = Session["user"].ToString();  //read the user name
                userId = (int)(Session["uid"]);    //convert session to int - read the id
                var checkUser = db.abstract_user.Where(i => i.id == userId).FirstOrDefault();

                if (checkUser.role == "Appraiser")  // access only for appraisers.
                {

                    base.initFunc();  //init the base functions - user CP


                    //init functions//




                    //END init functions//

                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "web");  //if not appraiser, redirect to Index
                }
            }

            else
            {
                return RedirectToAction("Login", "web");  //if not logged in, redirect to login
            }
        } //END appraiserHome



    }
}