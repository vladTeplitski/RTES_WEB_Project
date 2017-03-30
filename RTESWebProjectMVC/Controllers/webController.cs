using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTESWebProjectMVC.Controllers
{
    public class webController : baseController //extend from base controller
    {
        
        public ActionResult Index() // home page action
        {
            base.initFunc();  //init the base functions - user CP
            return View();  // show home page view = index

        }

        public ActionResult Login() //Login action
        {
            ViewBag.loginAlert1 = "none";  //show alert
            ViewBag.passedUser = Session["user"];
            ViewBag.passedPass = Session["uid"];
            return View();  // show the Login view
        }

        public ActionResult wrongLogin() //case of wrong login
        {
            ViewBag.loginAlert1 = "inline";  //show alert
            return View("Login"); // redirect to login view
        }

        [HttpPost] //main login function
        public ActionResult loginFunc(String lgUser,String lgPass)
        {

            using (var db = new Models.rtesEntities1())  // create new DB object
            {
                var user = db.abstract_user.Where(i => i.name == lgUser && i.password == lgPass).FirstOrDefault();  // SQL query using "Linq"
                if (user == null)  // no results
                {
                      //show alert
                    return RedirectToAction("wrongLogin", "web");
                }
                else  //found result = user authorized
                {
                    Session["user"] = user.name;   //set sessions values
                    Session["uid"] = user.id;      //set sessions values
                    ViewBag.loginAlert1 = "none";

                    //navigation to pages by user rank
                    if (user.role == "Operator")
                    {
                        return RedirectToAction("operatorHome", "operator");
                        
                    }
                    else if (user.role == "Client")
                    {
                        return RedirectToAction("client", "client");
                    }
                    else
                    {
                        return RedirectToAction("Index", "web");
                    }
                }
            }
        }


        public ActionResult Logout()  // Logout action
        {
            base.initFunc();  //init the base functions
            return View(); // show the Logout view
        }

        public ActionResult LogoutFunc()
        {
            Session.Abandon();  //empty the session
            return RedirectToAction("Index", "web");  //back to homepage
        }

    }
}