using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTESWebProjectMVC.Controllers
{
    public class appraiserController : baseController
    {
        int x;

        // GET: appraiser
        public ActionResult appraiserHome()
        {
            string userName;
            int userId;
            // Models.appraiserTaskList[] list;
            if (Session["user"] != null)  //if logged in user
            {
                var db = new Models.rtesEntities1();
                userName = Session["user"].ToString();  //read the user name
                userId = (int)(Session["uid"]);    //convert session to int - read the id
                var checkUser = db.abstract_user.Where(i => i.id == userId).FirstOrDefault();

                if (checkUser.role == "Appraiser")  // access only for appraisers.
                {

                    base.initFunc();  //init the base functions - user CP

                    var listTask = db.appraiserTaskList.Where(x => x.appraID == userId && x.status == 0).OrderBy(q => q.date).ToList();

                    if (listTask.Count() != 0)//have tasks in db
                    {
                        ViewBag.appraiserTasks = listTask;
                        ViewBag.showTasksMessage = "none";
                        ViewBag.showTasksTable = "table";
                    }
                    else //no reports in db
                    {
                        ViewBag.showTasksMessage = "inline";
                        ViewBag.showTasksTable = "none";
                    }
                    Session["appraiserFlag"]=1;
                    ViewBag.appraiserFlag = 1;

                   


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



        public ActionResult updateTaskTable(string update)
        {

            int userId = (int)(Session["uid"]);


            var db = new Models.rtesEntities1();
            var listTask = db.appraiserTaskList.Where(x => x.appraID == userId && x.status == 0).OrderBy(q => q.date).ToList();

            if (listTask.Count() != 0)//have tasks in db
            {
                ViewBag.appraiserTasks = listTask;
                ViewBag.showTasksMessage = "none";
                ViewBag.showTasksTable = "table";
            }
            else //no reports in db
            {
                ViewBag.showTasksMessage = "inline";
                ViewBag.showTasksTable = "none";
            }

            return View();
        }



        public ActionResult openForm(int report)  //Show client report info window
        {
            base.initFunc();  //init the base functions - user CP
            Session["emergencyReportId"] = report;
           ViewBag.report = report;

            //get the current date and time
            DateTime now = DateTime.Now;
            ViewBag.date2 = now.ToString("dd.MM.yyyy");
            ViewBag.hour2 = now.ToString("hh:mm tt");

            return View("appraiserReport");
        }

        [HttpPost]
        public ActionResult createReport(FormCollection form)
        {


            var report = Session["emergencyReportId"];
            var db = new Models.rtesEntities1();

            var maxId = db.appraiserReport.DefaultIfEmpty().Max(r => r == null ? 0 : r.appraiserReportId); //get the max report Id
            x = Convert.ToInt32(maxId.ToString());//convert type of string to int
            x = x + 1;


            //images
            HttpPostedFileBase img1 = Request.Files["imgApp1"];
            HttpPostedFileBase img2 = Request.Files["imgApp2"];
            HttpPostedFileBase img3 = Request.Files["imgApp3"];
            HttpPostedFileBase img4 = Request.Files["imgApp4"];
            HttpPostedFileBase img5 = Request.Files["imgApp5"];

            byte[] byteFile1=null;
            byte[] byteFile2=null;
            byte[] byteFile3=null;
            byte[] byteFile4=null;
            byte[] byteFile5=null;

            if (img1 != null)
            {
                int contentLength = img1.ContentLength;

                 byteFile1 = new byte[contentLength];

                img1.InputStream.Read(byteFile1, 0, contentLength);
            }

            if (img2 != null)
            {
                int contentLength2 = img2.ContentLength;

                byteFile2 = new byte[contentLength2];

                img2.InputStream.Read(byteFile2, 0, contentLength2);
            }

            if (img3 != null)
            {
                int contentLength3 = img3.ContentLength;

                byteFile3= new byte[contentLength3];

                img3.InputStream.Read(byteFile3, 0, contentLength3);
            }

            if (img4 != null)
            {
                int contentLength4 = img4.ContentLength;

                byteFile4 = new byte[contentLength4];

                img4.InputStream.Read(byteFile4, 0, contentLength4);
            }

            if (img5 != null)
            {
                int contentLength5 = img5.ContentLength;

                byteFile5 = new byte[contentLength5];

                img5.InputStream.Read(byteFile5, 0, contentLength5);
            }

            if (form != null)
            {

                db.appraiserReport.Add(new Models.appraiserReport()
                {
                    appraiserId = (int)(Session["uid"]),
                    appraiserReportId = x,
                    emergencyReportID = (int)report,
                    summaryDamage1 = form["subject"].ToString(),
                    amount1 = Convert.ToInt32(form["amount"].ToString()),
                    summaryDamage2 = form["subject2"].ToString(),
                    amount2 = Convert.ToInt32(form["amount2"].ToString()),
                    summaryDamage3 = form["subject3"].ToString(),
                    amount3 = Convert.ToInt32(form["amount3"].ToString()),
                    summaryDamage4 = form["subject4"].ToString(),
                    amount4 = Convert.ToInt32(form["amount4"].ToString()),
                    summaryDamage5 = form["subject5"].ToString(),
                    amount5 = Convert.ToInt32(form["amount5"].ToString()),
                    picture1 = byteFile1,
                    picture2 = byteFile2,
                    picture3 = byteFile3,
                    picture4 = byteFile4,
                    picture5 = byteFile5,
                    sumTotal = Convert.ToInt32(form["sumTotal"].ToString()),
                    comments = form["comments"].ToString()

                });
                var listTask1 = db.appraiserTaskList.Where(x => x.reportId == (int)report).FirstOrDefault();
                listTask1.status = 1;

                var changeStatusEmergencyReport = db.emergencyReport.Where(h => h.reportID == (int)report).FirstOrDefault();
                changeStatusEmergencyReport.status = 2;
                db.SaveChanges();
            }
           
            return RedirectToAction("appraiserHome", "appraiser");
            
        }
    }//End class


}