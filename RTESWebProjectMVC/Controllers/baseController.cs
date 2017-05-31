using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTESWebProjectMVC.Controllers
{
    public class baseController : Controller
    {
        // GET: base
        public baseController() //base controller for common functionality for all other controllers.
        {

            initFunc();
        }

        public void initFunc()//base controller functionality - init
        {
            string userName;
            int userId;
            if (Session != null && Session["user"] != null)
            {
                ViewBag.passedUser1 = Session["user"];
                ViewBag.passedPass1 = Session["uid"];
            }

            //init
            ViewBag.clientZone = "none";
            ViewBag.operatorZone = "none";
            ViewBag.driverZone = "none";
            ViewBag.appraiserZone = "none";


            //check session for logged in user

            if (Session != null && Session["user"] != null)  //logged in user
            {

                //Settings inits & check status of flags
                settingsInit();

                //operator inits
                ViewBag.showOpNotif = "none";
                if (TempData["opEditedFlag"] != null) // flag - settings edited by operator ViewBag.showOpNotif)
                {
                    ViewBag.showOpNotif = "block";
                    TempData["opEditedFlag"] = null;
                }
                //END operator inits

                //client inits
                ViewBag.showReportNotif = "none";
                if (TempData["reportNotifFlag"] != null) // flag - report sent by client - success notification
                {
                    ViewBag.showReportNotif = "block";
                    TempData["reportNotifFlag"] = null;
                }





                //end client inits

                //show hiddent user cp fields
                ViewBag.loginBtnDisp = "none";
                ViewBag.logoutBtnDisp = "inline";  //show logout button


                ViewBag.companyPanelDisp = "inline";
                ViewBag.messagesPanelDisp = "inline";
                using (var db = new Models.rtesEntities1())
                {
                    userName = Session["user"].ToString();  //read the user name
                    userId = (int)(Session["uid"]);    //convert session to int - read the id


                    //read from database
                    var user = db.abstract_user.Where(i => i.id == userId).FirstOrDefault();

                    //update user cp
                    ViewBag.companyLabel = "Company:" + " " + user.company;
                    ViewBag.usernameLabel = userName + " " + user.familyName;
                    //count messages
                    var msgs = db.messagesTable.Where(i => i.userID == userId).Count();
                    ViewBag.msgsNumLabel = "Messages: [" + msgs + "]";

                    if (user.role == "Client")
                    {
                        ViewBag.clientZone = "inline";
                        ViewBag.showOptionsBtn = "block";  //show options button
                    }
                    else if (user.role == "Operator")
                    {
                        ViewBag.operatorZone = "inline";
                        ViewBag.showOptionsBtn = "block";   //show options button
                    }
                    else if (user.role == "Driver")
                    {
                        ViewBag.driverZone = "inline";
                        ViewBag.showOptionsBtn = "block";   //show options button
                    }
                    else if (user.role == "Appraiser")
                    {
                        ViewBag.appraiserZone = "inline";
                        ViewBag.showOptionsBtn = "block";   //show options button
                    }

                }
            }

            else  //guest mode
            {
                //control the buttons and panels to display
                ViewBag.showOptionsBtn = "none";
                ViewBag.usernameLabel = "Guest (please login)";
                ViewBag.companyLabel = "Company: [Guest]";
                ViewBag.msgsNumLabel = "Messages: [Guest]";
                ViewBag.companyPanelDisp = "none";
                ViewBag.messagesPanelDisp = "none";
                ViewBag.loginBtnDisp = "inline";
                ViewBag.logoutBtnDisp = "none";

            }
        }

        public void settingsInit()  // init user settings functionality
        {
            //init viewbags of settings alerts
            ViewBag.presentPswdNotif = "none";
            ViewBag.successPswdNotif = "none";
            ViewBag.successEmailNotif = "none";
            ViewBag.presentEmailNotif = "none";
            ViewBag.successPhoneNotif = "none";

            if (Session["settingsFlag"] != null)
            {
                ViewBag.showSettingsBox = "inline"; // show settings = settings were changed.
                Session["settingsFlag"] = null;

                if (TempData["settingsFlag1"] != null) // check if flag is not null - pass notification
                {
                    //password alert
                    if ((int)TempData["settingsFlag1"] == 1)
                    {
                        ViewBag.presentPswdNotif = "none";
                        ViewBag.successPswdNotif = "inline";
                        TempData["settingsFlag1"] = null;  //init flag
                    }
                    else if ((int)TempData["settingsFlag1"] == 0)
                    {
                        ViewBag.presentPswdNotif = "inline";
                        ViewBag.successPswdNotif = "none";
                        TempData["settingsFlag1"] = null;  //init flag
                    }
                }


                    //email alert
                    if (TempData["settingsFlag2"] != null) // check if flag is not null - email notification
                {
                        if ((int)TempData["settingsFlag2"] == 1)
                        {
                            ViewBag.successEmailNotif = "inline";
                            ViewBag.presentEmailNotif = "none";
                            TempData["settingsFlag2"] = null;  //init flag
                        }
                        else if ((int)TempData["settingsFlag2"] == 0)
                        {
                            ViewBag.successEmailNotif = "none";
                            ViewBag.presentEmailNotif = "inline";
                            TempData["settingsFlag2"] = null;  //init flag
                        }
                    }

                    //phone alert
                    if (TempData["settingsFlag3"] != null) // check if flag is not null - phone notification
                {
                        
                        if ((int)TempData["settingsFlag3"] == 1)
                        {
                            ViewBag.successPhoneNotif = "inline";
                            TempData["settingsFlag3"] = null;  //init flag
                        }
                    }
            }
            else
            {
                ViewBag.showSettingsBox = "none";
            }


        }//END Settings inits & check status of flags
    }
}
