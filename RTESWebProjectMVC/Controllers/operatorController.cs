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
        public ActionResult operatorHome(string searchString)
        {
            string userName;
            int userId;

            if (Session["user"] != null)  //if logged in user
            {
                var db = new Models.rtesEntities1();
                userName = Session["user"].ToString();  //read the user name
                userId = (int)(Session["uid"]);    //convert session to int - read the id
                var checkUser = db.abstract_user.Where(i => i.id == userId).FirstOrDefault();

                if(checkUser.role=="Operator")  // access only for operators.
                {

                base.initFunc();  //init the base functions - user CP

                //init messages gui
                ViewBag.usersFromDbAlert = "none";
                ViewBag.showMsgANorifGui = "none";
                if (Session["msgNotif"] != null && Session["selected"] != null && Session["selectedName"] != null)
                {
                    ViewBag.showMsgANorifGui = "inline";
                    Session["msgNotif"] = null;
                    ViewBag.sentId = Session["selected"];
                    ViewBag.sentName = Session["selectedName"];
                }
                //END init messages gui

                //init DB


                //init functions
                usersFromDB();   //update users list from db to view
                allReportsFromDb(); //update existing reports list from db to view

                //end init functions

                return View();
                }
                else
                {
                    return RedirectToAction("Index", "web");  //if not operator, redirect to Index
                }
            }

            else
            {
                return RedirectToAction("Login", "web");  //if not logged in, redirect to login
            }
        }//end operatorHome function


        public void usersFromDB()  //show the client reports function
        {

            using (var db = new Models.rtesEntities1())
            {

                //read from database
                var users = db.abstract_user.ToList();

                if (users.Any())
                {
                    ViewBag.usersFromDbAlert = "none";
                    ViewBag.usersDB = users;


                }
                else //no users in db
                {

                    ViewBag.usersFromDbAlert = "inline"; // show alert

                }
            }
        }//end usersFromDB function


        public ActionResult openMessageUser(String id)
        {

            int x = Int32.Parse(id.ToString());  //convert search id input to integer

            Session["selected"] = x;

            ViewBag.showMessageWindow = "Block";

            if (Session["user"] != null)  //if logged in user
            { 

                if (Request.IsAjaxRequest())  //validate ajax
                {

                    using (var db = new Models.rtesEntities1())  //db
                    {
                    
                    var result = db.abstract_user.Where(i => i.id == x).FirstOrDefault();  //get the result from db

                    if (result.id == x)  //if result found
                    {
                        ViewBag.showSearchResult = "inline";
                        ViewBag.searchResultAlert = "none";  //no alert
                        ViewBag.foundUserName = result.name + " " + result.familyName;
                        ViewBag.foundUserId = result.id;
                        ViewBag.foundUserEmail = result.email;
                        Session["selectedName"] = result.name;
                    }

                    else  //no results
                    {
                        ViewBag.showSearchResult = "none";
                        ViewBag.searchResultAlert = "inline";  //show alert for no results
                    }
                }

                return PartialView("messagePartial");  //using partial view
                }
                else
                return PartialView("messagePartial");

            }
            else
            {
                return RedirectToAction("Login", "web");  //if disconnected, redirect to login
            }
        }//end openMessageUser


        public ActionResult sendMessage(String Message)
        {
            int resultId = 0;
            resultId = (int)(Session["selected"]); //passed by session
            String selectedName;
            selectedName = (String)(Session["selectedName"]);


            using (var db = new Models.rtesEntities1())
            {

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
                    userID = resultId,
                    content = Message,
                    date = DateTime.Now.ToString()  //get current date
                };
                db.messagesTable.Add(msg); //add new row to db
                db.SaveChanges();
            }


            Session["msgNotif"] = "true";
            return RedirectToAction("operatorHome", "operator");
        }//end sendMessage


        public void allReportsFromDb()  //init reports table from db
        {
            using (var db = new Models.rtesEntities1())
            {

                //read from database
                
                var allReportsDB = db.emergencyReport.ToList();

                if (allReportsDB.Any())
                {
                    ViewBag.allReportsFromDbAlert = "none"; // hide alert
                    ViewBag.allReportsDB = allReportsDB;


                }
                else //no users in db
                {

                    ViewBag.allReportsFromDbAlert = "inline"; // show alert

                }
            }

        }//end allReportsFromDb

        public ActionResult openReportDetails(String id)  // show selected report details
        {
            return RedirectToAction("operatorHome", "operator");
        }//end openReportDetails


    }

}
