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


                    if (Session["showCloseTruckNotif"] != null)
                    {

                        ViewBag.showCloseTruckNotif = "inline";
                    }

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
            string userName;
            int userId;

            if (Session["user"] != null)  //if logged in user
            {
                
                    userName = Session["user"].ToString();  //read the user name
                    userId = (int)(Session["uid"]);    //convert session to int - read the id


                    Models.tasksModel[] tasks1=new Models.tasksModel[3];

                    Models.tasksOrder tasks3 = new Models.tasksOrder();
                    using (var db = new Models.rtesEntities1())
                    {

                        //update reports list
                        //status: 0 = open, 1 = closed
                        //get all tasks assigned for this driver

                        var tasks2 = from r in db.truckDriver
                                     where r.abstractUserId == userId
                                     select new Models.tasksOrder { priority1 = (int)r.priority1, priority2 = (int)r.priority2, priority3 = (int)r.priority3, priority4 = (int)r.priority4, priority5 = (int)r.priority5, priority6 = (int)r.priority6, priority1Role = r.priority1Role, priority2Role = r.priority2Role, priority3Role = r.priority3Role, priority4Role = r.priority4Role, priority5Role = r.priority5Role, priority6Role = r.priority6Role };


                   

                        foreach (var o in tasks2)
                        {
                            tasks3 = o;
                        }


                        if (tasks2.Any())
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
                    return PartialView("tasksGuiPartial", tasks3); // open partial view and send the model

            }

            else
            {
                return RedirectToAction("Login", "web");  //if not logged in, redirect to login
            }
        }

        int count = 0;

        [HttpPost]
        public ActionResult getCoordinates(string latForm, string lngForm, string truckAddress)
        {
            int userId;


            using (var db = new Models.rtesEntities1())
            {
                userId = (int)(Session["uid"]);    //dirver's id
                var driver = db.truckDriver.Where(i => i.abstractUserId == userId).FirstOrDefault();

                driver.Latitude = latForm;
                driver.Longitude = lngForm;
                driver.location = truckAddress;

                db.SaveChanges();

                count = count + 1;
                ViewBag.counter = "Count= " + count;
                ViewBag.loc123 = truckAddress;

            }
                return Redirect(Request.UrlReferrer.PathAndQuery);  //get back to the present view
        }


        public ActionResult finishTaskDriver(String reportId,String act) //complate task by truck driver
        {
            //act: close the task and move to appraiser, that means truck deriver unloaded. or truck driver loaded, and the load task should be removed from truck driver app, but task remains.
            int actInt = Int32.Parse(act.ToString());

            int x = Int32.Parse(reportId.ToString());  //convert search id input to integer
            int userId;
            userId = (int)(Session["uid"]);    //convert session to int - read the id
            //Session["selected"] = x;

            if (Session["user"] != null)  //if logged in user
            {
                var db = new Models.rtesEntities1();
                int flag_load = 0;  // indicate if load, than +1 cargo

                var priority = db.truckDriver.Where(g => g.abstractUserId == userId).FirstOrDefault();

                //start load 
                if (priority.priority1 == x && priority.priority1Role != "Unload")
                {
                    flag_load = 1;
                    priority.priority1 = 0;
                }

                if (priority.priority2 == x && priority.priority2Role != "Unload")
                {
                    flag_load = 1;
                    priority.priority2 = 0;
                }

                if (priority.priority3 == x && priority.priority3Role != "Unload")
                {
                    flag_load = 1;
                    priority.priority3 = 0;
                }

                if (priority.priority4 == x && priority.priority4Role != "Unload")
                {
                    flag_load = 1;
                    priority.priority4 = 0;
                }

                if (priority.priority5 == x && priority.priority5Role != "Unload")
                {
                    flag_load = 1;
                    priority.priority5 = 0;
                }

                if (priority.priority6 == x && priority.priority6Role != "Unload")
                {
                    flag_load = 1;
                    priority.priority6 = 0;
                }
                //End load 

                //start unload 

                if (priority.priority1 == x && flag_load==0)
                {
                    
                    priority.priority1 = 0;
                }

                if (priority.priority2 == x && flag_load == 0)
                {
                    
                    priority.priority2 = 0;
                }

                if (priority.priority3 == x && flag_load == 0)
                {
                  
                    priority.priority3 = 0;
                }

                if (priority.priority4 == x && flag_load == 0)
                {
                    
                    priority.priority4 = 0;
                }

                if (priority.priority5 == x && flag_load == 0)
                {
                  
                    priority.priority5 = 0;
                }

                if (priority.priority6 == x && flag_load == 0)
                {
                    
                    priority.priority6 = 0;
                }
                //End unload 

                if (flag_load == 1)//load 
                {
                    var driver = db.truckDriver.Where(i => i.abstractUserId == userId).FirstOrDefault();
                    driver.cargo = driver.cargo + 1;
                }

                if (actInt == 1)
                {
                    var report = db.emergencyReport.Where(i => i.reportID == x).FirstOrDefault();
                    var driver = db.truckDriver.Where(i => i.abstractUserId == userId).FirstOrDefault();

                    driver.cargo = driver.cargo - 1;   // update cargo after unload
                    driver.TasksCounter = driver.TasksCounter - 1;  // update tasks counter after unloading
                    report.status = 1; // //finished towing - moving to appraiser

                    db.SaveChanges();

                    //schecduling appraiser to report
                    var reportRow = db.emergencyReport.Where(j => j.reportID == x).FirstOrDefault();

                    var clientDetails = db.abstract_user.Where(t => t.id == reportRow.clientAbstractUserId).FirstOrDefault();


                    

                    string clientPhone = clientDetails.userPhoneNumber;
                    string clientName = clientDetails.name;
                    string locationClient = reportRow.towing_destination;

                    var u = 0;
                    var maxId1 = db.appraiserTaskList.DefaultIfEmpty().Max(r => r == null ? 0 : r.taskID); //get the max report Id
                    u = Convert.ToInt32(maxId1.ToString());//convert type of string to int
                    u = u + 1;

                    var appr = (from p in db.appraiser
                                orderby p.taskCount
                                select p.appraiserID).First();


                    int appraiserID = Convert.ToInt32(appr.ToString());

                    db.appraiserTaskList.Add(new Models.appraiserTaskList()
                    {
                        reportId = x,
                        taskID = u,
                        location = locationClient,
                        clientName = clientName,
                        clientPhone = clientPhone,
                        status = 0,
                        appraID = appraiserID

                    });

                    db.SaveChanges();


                    var updateTaskCount = db.appraiser.Where(i => i.appraiserID == appraiserID).FirstOrDefault();
                    updateTaskCount.taskCount = updateTaskCount.taskCount + 1;
                    var appraiserDetails = db.abstract_user.Where(g => g.id == updateTaskCount.appraiserID).FirstOrDefault();

                    //Session["appraiserPhone"] = appraiserDetails.userPhoneNumber;
                    //Session["appraiserName"] = appraiserDetails.name;
                    //Session["showScheduleAppraiserNotif"] = 1;

                    //End schecduling appraiser to report

                    //generate message number - key in db
                    Random rand = new Random();
                        int msgNumber = 0;
                        msgNumber = rand.Next(1000, 100000);
                        var msgsDb = db.messagesTable.Where(i => i.msgNum == msgNumber).DefaultIfEmpty().First();
                        while (msgsDb != null)
                        {
                            msgNumber = rand.Next(1000, 100000);
                            msgsDb = db.messagesTable.Where(i => i.msgNum == msgNumber).DefaultIfEmpty().First();

                        }

                        Models.messagesTable msg = new Models.messagesTable
                        {
                            msgNum = msgNumber,    //add the new message generated number
                            userID = clientDetails.id,
                            content = "Appraiser is assigned! "+ "Appraiser name: "+ appraiserDetails.name +"Appraiser phone: "+ appraiserDetails.userPhoneNumber,
                            date = DateTime.Now.ToString()  //get current date
                        };
                        db.messagesTable.Add(msg); //add new row to db
                    db.SaveChanges();
                    Session["msgNotif"] = "true";

                }

                Session["showCloseTruckNotif"] = 1;

                db.SaveChanges();  // save changes to db
                    

                return RedirectToAction("truckDriverHome", "truckDriver");
            }
            else
            {
                return RedirectToAction("Login", "web");  //if disconnected, redirect to login
            }
        }//end finishTaskDriver


        public ActionResult taskInfoDriver(String reportId) //editUserDetails Gui
        {

            int y = Int32.Parse(reportId.ToString());

            ViewBag.showtasksInfoPartial = "Block";

            Models.taskClientInfo info = new Models.taskClientInfo();

            if (Session["user"] != null)  //if logged in user
            {

                if (Request.IsAjaxRequest())  //validate ajax
                {
                    using (var db = new Models.rtesEntities1())
                    {
                        int x = Convert.ToInt32(reportId);  //convert to int

                          var getinfo = from a in db.abstract_user
                                        join c in db.client on a.id equals c.abstractUserId
                                        join r in db.emergencyReport on c.abstractUserId equals r.clientAbstractUserId
                                        where r.reportID == x
                                        select new Models.taskClientInfo { carModel = c.carModel, clientId=a.id, location = r.location, name = a.name , phone = a.userPhoneNumber, category = c.carCategory, licensePlate=(int)c.licensePlate };

                        foreach (var z in getinfo)
                        {
                            info = z;
                        }
                        //var details = db.emergencyReport.Where(i => i.reportID == x).FirstOrDefault();

                        //int clientId;

                        //ViewBag.clientLocation = details.location;   //client's location

                        //clientId = details.clientAbstractUserId;

                        //var details2 = db.abstract_user.Where(i => i.id == clientId).ToList();

                    }

                    return PartialView("taskInfoPartial",info);  //using partial view
                }
                else
                    return RedirectToAction("truckDriverHome", "truckDriver");

            }
            else
            {
                return RedirectToAction("Login", "web");  //if disconnected, redirect to login
            }
        }//end finishTaskDriver



    }
}