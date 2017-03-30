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
        public void initFunc()
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

            //check session for logged in user

            if (Session != null && Session["user"] != null)  //logged in user
            {

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
                    }
                    else if (user.role == "Operator")
                    {
                        ViewBag.clientZone = "inline";
                        ViewBag.operatorZone = "inline";
                    }

                }
            }

            else  //guest mode
            {
                //control the buttons and panels to display
                ViewBag.usernameLabel = "Guest (please login)";
                ViewBag.companyLabel = "Company: [Guest]";
                ViewBag.msgsNumLabel = "Messages: [Guest]";
                ViewBag.companyPanelDisp = "none";
                ViewBag.messagesPanelDisp = "none";
                ViewBag.loginBtnDisp = "inline";
                ViewBag.logoutBtnDisp = "none";

            }
        }
    }
}
