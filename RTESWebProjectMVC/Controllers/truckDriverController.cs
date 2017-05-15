using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTESWebProjectMVC.Controllers
{
    public class truckDriverController : baseController
    {
        // GET: truckDriver
        public ActionResult truckDriverHome()
        {
            string userName;
            int userId;

            if (Session["user"] != null)  //if logged in user
            {
                var db = new Models.rtesEntities1();
                userName = Session["user"].ToString();  //read the user name
                userId = (int)(Session["uid"]);    //convert session to int - read the id
                var checkUser = db.abstract_user.Where(i => i.id == userId).FirstOrDefault();

                if (checkUser.role == "Driver")  // access only for truck drivers.
                {

                    base.initFunc();  //init the base functions - user CP


                    //init functions//

                    


                    //END init functions//

                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "web");  //if not driver, redirect to Index
                }
            }

            else
            {
                return RedirectToAction("Login", "web");  //if not logged in, redirect to login
            }
        } //END truckDriverHome



        [OutputCache(NoStore = true, Location = System.Web.UI.OutputCacheLocation.Client, Duration = 5)] // every 5 sec
        public ActionResult GetTasksList()

        {
            Models.tasksModel[] tasks1=new Models.tasksModel[3];
            using (var db = new Models.rtesEntities1())
            {

                //update reports list
                //status: 0 = open, 1 = closed

                var tasks = from t in db.emergencyReport
                            join x in db.taskList on t.reportID equals x.reportId
                            join v in db.abstract_user on t.clientAbstractUserId equals v.id
                            join c in db.client on t.clientAbstractUserId equals c.abstractUserId
                            where x.status == 0 && t.callForTowing== true
                            select new Models.tasksModel { reportId = t.reportID, location = t.location, towing_destination = t.towing_destination, familyName = v.familyName, name = v.name, userPhoneNumber = v.userPhoneNumber, carCategory = c.carCategory, carModel = c.carModel};

                int i = 0;
                foreach(var y in tasks)
                {
                    tasks1[i] = y;
                    i++;
                }


                if (tasks.Any())
                {
                    ViewBag.showTasks = "table";
                    ViewBag.showTasksNotif = "none";
                }
                else //no reports in db
                {
                    ViewBag.showTasks = "none";
                    ViewBag.showTasksNotif = "inline";
                }

                
            }
            return PartialView("tasksGuiPartial", tasks1); // open partial view and send the model
        }

        int count = 0;

        [HttpPost]
        public ActionResult getCoordinates(string latForm, string lngForm)
        {
            int userId;


            using (var db = new Models.rtesEntities1())
            {
                userId = (int)(Session["uid"]);    //dirver's id
                var driver = db.truckDriver.Where(i => i.abstractUserId == userId).FirstOrDefault();

                driver.Latitude = latForm;
                driver.Longitude = lngForm;

                db.SaveChanges();

                count = count + 1;
                ViewBag.counter = "Count= " + count;


            }
                return Redirect(Request.UrlReferrer.PathAndQuery);  //get back to the present view
        }




    }
}