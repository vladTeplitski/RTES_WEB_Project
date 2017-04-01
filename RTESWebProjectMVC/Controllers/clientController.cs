using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTESWebProjectMVC.Controllers
{
    public class clientController : baseController
    {
        
        // GET: client
        public ActionResult client()
        {
            string userName;
            int userId;

            base.initFunc();  //init the base functions - user CP


            //Startup inits
            ViewBag.showClientRepInfo = "none";


            //END Startup inits


            //Build client page

            using (var db = new Models.rtesEntities1())
            {
                userName = Session["user"].ToString();  //read the user name
                userId = (int)(Session["uid"]);    //convert session to int - read the id

                //read data from database
                var user = db.abstract_user.Where(i => i.id == userId).FirstOrDefault();
                var client = db.client.Where(i => i.abstractUserId == userId).DefaultIfEmpty().First(); ;

                if (client != null)  //if client account exists
                {

                    //Emergency reports library init - client
                    reportsFromDB(userId);



                }


                else  //there is no client account
                {
                    //reports table - non client
                    ViewBag.repDB = null;
                    ViewBag.clientRepListAlert = "inline";  //show reports alert
                    ViewBag.showRepDb = "none"; //hide reports table




                }
            }
            return View();

        }//end client function


        public void reportsFromDB(int userId)  //show the client reports function
        {

            using (var db = new Models.rtesEntities1())
            {
                ViewBag.clientRepListAlert = "none";  //hide alert
                ViewBag.showRepDb = "table";  //show table
                //read from database
                var reportsDb = db.emergencyReport.Where(i => i.clientAbstractUserId == userId).ToList();

                if (reportsDb.Any()) 
                {
                    ViewBag.repDB = reportsDb;


                }
                else //no reports for client
                {
                    
                   ViewBag.clientRepListAlert = "inline"; // show alert
                   ViewBag.repDB = null;
                   ViewBag.showRepDb = "none"; //hide table
                }
            }
        }//end reportsFromDB function


        public ActionResult showReportInfo(int id)  //Show client report info window
        {
            
            ViewBag.showClientRepInfo = "Block";  //show client report info panel

            if (Request.IsAjaxRequest())
            {

                using (var db = new Models.rtesEntities1())
                {
                    int x = Int32.Parse(id.ToString());
                    var reportsDb = db.emergencyReport.Where(i => i.reportID == x).FirstOrDefault();

                    System.Text.StringBuilder list = new System.Text.StringBuilder();

                    list.AppendLine("<table class=\"table table-bordered\">");
                    list.AppendLine("<tr><td>Client ID:</td>");
                    list.AppendLine("<td>");
                    list.AppendLine(reportsDb.clientAbstractUserId.ToString());
                    list.AppendLine("</td></tr>");
                    list.AppendLine("<tr><td>report ID:</td>");
                    list.AppendLine("<td>");
                    list.AppendLine(reportsDb.reportID.ToString());
                    list.AppendLine("</td></tr>");
                    list.AppendLine("<tr><td>Location:</td>");
                    list.AppendLine("<td>");
                    list.AppendLine(reportsDb.location);
                    list.AppendLine("</td></tr>");
                    list.AppendLine("<tr><td>Towing destination:</td>");
                    list.AppendLine("<td>");
                    list.AppendLine(reportsDb.towing_destination);
                    list.AppendLine("</td></tr>");
                    list.AppendLine("<tr>");
                    list.AppendLine("<tr><td>Witness name:</td>");
                    list.AppendLine("<td>");
                    list.AppendLine(reportsDb.accident_witness_name);
                    list.AppendLine("</td></tr>");
                    list.AppendLine("<tr><td>Witness phone number:</td>");
                    list.AppendLine("<td>");
                    list.AppendLine(reportsDb.accident_witness_phone.ToString());
                    list.AppendLine("</td></tr>");
                    list.AppendLine("<tr><td>Comments:</td>");
                    list.AppendLine("<td>");
                    list.AppendLine(reportsDb.comments);
                    list.AppendLine("</td></tr>");
                    list.AppendLine("</table>");

                    ViewBag.clientRepInfo = list.ToString();
                }

                return PartialView("reportInfoPartial");  //using partial view
            }
            else
                return PartialView("reportInfoPartial");

        }//end showReportInfo function



        public ActionResult NewReport()
        {
            base.initFunc();//init the base functions - user CP
            return View();
        }//end NewReport function
    }


}