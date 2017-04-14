using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTESWebProjectMVC.Controllers
{
    public class clientController : baseController
    {
        string userName;
        int userId;
        string date1;
        string hour1;
        int x;
        //int check;

        // GET: client
        public ActionResult client()
        {

            base.initFunc();  //init the base functions - user CP


            //Startup inits
            ViewBag.showClientRepInfo = "none";
            //END Startup inits

          

            //Build client page

            using (var db = new Models.rtesEntities1())
            {
                 userName = Session["user"].ToString();  //read the user name
                 userId = Convert.ToInt32(Session["uid"]);    //convert session to int - read the id

                personalDetail(userId);
                //read data from database
                
                var user = db.abstract_user.Where(i => i.id == userId).FirstOrDefault();
                var client = db.client.Where(i => i.abstractUserId == userId).DefaultIfEmpty().First();



                if (client != null)  //if client account exists
                {
                    //Emergency reports library init - client
                    reportsFromDB(userId);

                    //Messages init - client
                    messagesFromDB(userId);
                }
                else  //NOT a client account
                {
                    //reports table - non client
                    ViewBag.repDB = null;
                    ViewBag.clientRepListAlert = "inline";  //show reports alert
                    ViewBag.showRepDb = "none"; //hide reports table
                    ViewBag.showMsgDb = "none";  //hide messages table
                }

                
            }
            return View();

        }//end client function

        //initial the personal details of the client
        public void personalDetail(int userId)
        {
            userId = Convert.ToInt32(Session["uid"]);    //convert session to int - read the id

            using (var db = new Models.rtesEntities1())
            {
                var client = db.client.Where(i => i.abstractUserId == userId).DefaultIfEmpty().First();

                ViewBag.carCategory = client.carCategory.ToString();
                ViewBag.carModel = client.carModel.ToString();
                ViewBag.YearOfManuFacture = client.carManufactureYear.ToString();
                ViewBag.liceansePlate = client.licensePlate.ToString();
                ViewBag.InsuranceCompanyName = client.insuranceCompanyName.ToString();
                ViewBag.InsuranceAgentName = client.insuranceAgentName.ToString();
                ViewBag.InsuranceAgentPhone = client.insuranceAgentPhoneNum.ToString();
                ViewBag.InsurancePolicyNumber = client.insurancePolicyNum.ToString();
                ViewBag.PolicyExpiration = client.policyEndDate.ToString();
                ViewBag.DrivingLicenseNumber = client.clientDrivingLicenseNumber.ToString();
                ViewBag.CarOwnerName = client.carOwnerName.ToString();
                ViewBag.CarOwnerID = client.carOwnerId.ToString();

            }

        }
        //end initial of personal details client 



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


        public void messagesFromDB(int userId)  //show the client messages
        {

            using (var db = new Models.rtesEntities1())
            {

                ViewBag.showMsgAlert = "none";  //hide alert
                ViewBag.showMsgDb = "table";  //show table
                                              //read from database
                var msgs = db.messagesTable.Where(i => i.userID == userId).OrderBy(a => a.date).ToList();
                var cnt = db.messagesTable.Where(i => i.userID == userId).Count();

                if (cnt == 0)   //if no messages
                {
                    ViewBag.showMsgAlert = "inline"; // show alert
                    ViewBag.showMsgDb = "none"; //hide table
                }
                else
                {
                    ViewBag.messagesDB = msgs;
                }

            }
        }//end messagesFromDB function




        public ActionResult NewReport()
        {
            base.initFunc();//init the base functions - user CP
            personalDetail(Convert.ToInt32(Session["uid"]));//call to personal detials function

            ViewBag.successfull = "none";
            
            //Current time and date
            DateTime now = DateTime.Now;
            ViewBag.date1 = now.ToString("dd.MM.yyyy");
            date1= now.ToString("dd.MM.yyyy");
            ViewBag.hour1 = now.ToString("hh:mm tt");
            hour1= now.ToString("hh:mm tt");
            //end

            return View();
        }//end NewReport function






        //create new report in db
        [HttpPost]
        public ActionResult send_Details_Func(string location,string towDest,string witName,string witPhone, string comments,string myName,string driverID,string driverPhone,string driverLicenseNum,string address1,string carOwnerName,string carOwnerId,string carLicensePlate,string carCategory,string carModel,string color1,string year,string compName,string policyNum,string agentName,string agentPhone)
        {
            
            using (var db = new Models.rtesEntities1())
            {
                userName = Session["user"].ToString();  //read the user name
                userId = (int)(Session["uid"]);    //convert session to int - read the id
                                                   // Create a new Order object.


                var maxId = db.emergencyReport.DefaultIfEmpty().Max(r => r == null ? 0 : r.reportID); //get the max report Id
                x = Convert.ToInt32(maxId.ToString());//convert type of string to int
                x = x + 1;

                // if (checkBox.ToString()!=null)
                // {
                // check = 1;
                //case1.callForTowing = 1;
                // }   
                DateTime now1 = DateTime.Now;
                db.emergencyReport.Add(new Models.emergencyReport() { reportID = x, clientAbstractUserId = userId, date = now1.ToString("dd.MM.yyyy"), hour = now1.ToString("hh:mm tt"), comments = comments, location = location, towing_destination = towDest, accident_witness_name = witName ,accident_witness_phone= Convert.ToInt32(witPhone) });
                //db.emergencyReport.Add(new Models.emergencyReport() { reportID = x, clientAbstractUserId = userId, date = date1, hour = hour1, comments = emerg.comments.ToString(), location = emerg.location.ToString(), towing_destination = emerg.towing_destination.ToString(), accident_witness_name = emerg.accident_witness_name.ToString() });
                db.SaveChanges();
                if (myName.ToString() != string.Empty)
                
                {
                    ViewBag.successfull = "block";
                    string colorName = color1.ToString();
                    db.third_party.Add(new Models.third_party()
                    {
                        emergencyReportId = x,
                        driverName = myName,
                        driverId = Convert.ToInt32(driverID),
                        phoneNumber = Convert.ToInt32(driverPhone),
                        drivingLicenseNumber = Convert.ToInt32(driverLicenseNum),
                        address = address1.ToString(),
                        carOwnerName = carOwnerName,
                        carOwnerId = Convert.ToInt32(carOwnerId),
                        licensePlateNumber = Convert.ToInt32(carLicensePlate),
                        carCategory = carCategory,
                        carModel = carModel,
                        carColor = colorName,
                        yearOfManufacture = Convert.ToInt32(year),
                        insuranceCompanyName = compName,
                        insurancePolicyNumber = Convert.ToInt32(policyNum),
                        insuranceAgentName = agentName,
                        insuranceAgentPhone = Convert.ToInt32(agentPhone)
                    });
                }

                db.SaveChanges();

            }

           
            return View("NewReport");
        }
        //end create new report in db
       

    }


}