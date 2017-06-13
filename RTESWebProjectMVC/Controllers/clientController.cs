using RTESWebProjectMVC.Models;
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

            if (Session["user"] != null)  //if logged in user
            {


                base.initFunc();  //init the base functions - user CP


                //Startup inits
                ViewBag.showClientRepInfo = "none";
                //END Startup inits



                //div of message delete
                ViewBag.messageDelete = "none";


                if (TempData["delete"] != null)
                {
                    ViewBag.messageDelete = "block";
                    TempData["delete"] = null;
                }
                //Build client page


                //algorithm - client lat/lng


                ViewBag.driverFlagModel = null;

                if (Session["AlgFlag"] != null && Session["driverFlagModel"] != null)
                {
                    //pass the lng & lat of the client side
                    ViewBag.clientLng = Session["clientLng"];
                    ViewBag.clientLat = Session["clientLat"];
                    ViewBag.driversList = Session["driversList"];
                    ViewBag.driversListSize = Session["driversListSize"];
                    ViewBag.driverFlagModel = 1;
                    Session["AlgFlag"] = null;  //init flag
                    Session["driverFlagModel"] = null;
                }





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
            }
            else
            {
                return RedirectToAction("Login", "web");  //if not logged in, redirect to login
            }

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

            imageData[] img= new imageData[5]; 
            ViewBag.showClientRepInfo = "Block";  //show client report info panel
           // imageData img = new imageData();
            if (Request.IsAjaxRequest())
            {

                using (var db = new Models.rtesEntities1())
                {
                  
                    int x = id;
                    var reportsDb = db.emergencyReport.Where(i => i.reportID == x).ToList();
                    var thirdPartyDb = db.third_party.Where(i => i.emergencyReportId == x).ToList();
                    var imageDb = db.image.Where(i => i.id == x).DefaultIfEmpty();

                    if (reportsDb.Any() && thirdPartyDb.Any())
                    {
                        ViewBag.clientReportsDBAlert = "none"; // hide alert no reports
                        ViewBag.clientReportsDB = reportsDb;
                        ViewBag.clientThirdPartyDb = thirdPartyDb;

                        if (imageDb != null)
                        {
                            //generate message number - key in db

                            
                            var imagesList = db.image.Where(i => i.id == x).ToList();
                            for (int i = 0; i < imagesList.Count; i++) {
                                img[i]=new imageData();
                                img[i].picture = imagesList[i].picture;
                            }
                                     
                            //int i = 0;
                             //foreach(image item in imageDb)
                            //{
                            //    img[i] = new imageData();
                             //   img[i].picture = item.picture;
                             //   i++;
                            // }

                           // Dictionary<int, string> postImages = new Dictionary<int, string>();
                           // foreach (var item in imageDb)
                            //{
                             //   byte[] buffer = item.picture;
                             //   postImages.Add(item.imgid, Convert.ToBase64String(buffer));
                            //}
                            //ViewBag.Images = postImages;
                           // img.
                        }


                    }
                    else //no users in db
                    {

                        ViewBag.allReportsFromDbAlert = "inline"; // show alert

                    }

                }

                return PartialView("reportInfoPartial", img);  //using partial view  
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

            if (Session["user"] != null)  //if logged in user
            {

                base.initFunc();//init the base functions - user CP
                personalDetail(Convert.ToInt32(Session["uid"]));//call to personal detials function

                ViewBag.successfull = "none";

                //Current time and date
                DateTime now = DateTime.Now;
                ViewBag.date1 = now.ToString("dd.MM.yyyy");
                date1 = now.ToString("dd.MM.yyyy");
                ViewBag.hour1 = now.ToString("hh:mm tt");
                hour1 = now.ToString("hh:mm tt");
                //end

                return View();

            }
            else
            {
                return RedirectToAction("Login", "web");  //if not logged in, redirect to login
            }


        }//end NewReport function

        [HttpPost]
        public ActionResult send_Details_Func(String location,String lat,String lng, String latDest, String lngDest, string towDest,string witName,string witPhone, string comments,string myName,string driverID,string driverPhone,string driverLicenseNum,string address1,string carOwnerName,string carOwnerId,string carLicensePlate,string carCategory,string carModel,string color1,string year,string compName,string policyNum,string agentName,string agentPhone, bool checkBox1 = false)
        {
            int checkStat;   
            using (var db = new Models.rtesEntities1())
            {
                userName = Session["user"].ToString();  //read the user name
                userId = (int)(Session["uid"]);    //convert session to int - read the id
                                                   
                var maxId = db.emergencyReport.DefaultIfEmpty().Max(r => r == null ? 0 : r.reportID); //get the max report Id
                x = Convert.ToInt32(maxId.ToString());//convert type of string to int
                x = x + 1;
                Session["clientRepIdNOW"] = x;

                if (checkBox1 == true)// Checks if need towing service
                {
                    checkStat = 0;//move to truck driver table
                }
                else checkStat = 1;//move to appraiser table


                DateTime now1 = DateTime.Now;
                db.emergencyReport.Add(new Models.emergencyReport() {
                    reportID = x,
                    clientAbstractUserId = userId,
                    date = now1.ToString("dd.MM.yyyy"),
                    hour = now1.ToString("hh:mm tt"),
                    comments = comments,
                    location = location,
                    towing_destination = towDest,
                    accident_witness_name = witName,
                    accident_witness_phone = witPhone,
                    callForTowing = checkBox1,
                    status = checkStat,
                    Latitude = lat,
                    Longitude = lng,
                    latDest = latDest,
                    lngDest = lngDest
                });       
                db.SaveChanges();

                //UPLOAD FILES//

                //files
                HttpPostedFileBase file = Request.Files["fileInput1"];
                HttpPostedFileBase file2 = Request.Files["fileInput"];

                //images
                HttpPostedFileBase img1 = Request.Files["imgIn1"];
                HttpPostedFileBase img2 = Request.Files["imgIn2"];
                HttpPostedFileBase img3 = Request.Files["imgIn3"];


                if (file != null)
                {
                    int imgNumber = 0;

                    int contentLength = file.ContentLength;

                    byte[] byteFile = new byte[contentLength];

                    file.InputStream.Read(byteFile, 0, contentLength);

                    //random image number
                    Random rand = new Random();
                    
                    imgNumber = rand.Next(100, 100000);
                    var imgsDb = db.image.Where(i => i.imgid == imgNumber).DefaultIfEmpty().First();
                    while (imgsDb != null)
                    {
                        imgNumber = rand.Next(100, 100000);
                        imgsDb = db.image.Where(i => i.imgid == imgNumber).DefaultIfEmpty().First();

                    }
                    //END random image number

                    db.image.Add(new Models.image()
                    {
                        id = x,
                        imgid = imgNumber,
                        picture = byteFile

                    });

                    db.SaveChanges();
                }


                if (file2 != null)
                {
                    int contentLength2 = file2.ContentLength;

                    byte[] byteFile = new byte[contentLength2];

                    file2.InputStream.Read(byteFile, 0, contentLength2);

                    //random image number
                    Random rand = new Random();
                    int imgNumber = 0;
                    imgNumber = rand.Next(100, 100000);
                    var imgsDb = db.image.Where(i => i.imgid == imgNumber).DefaultIfEmpty().First();
                    while (imgsDb != null)
                    {
                        imgNumber = rand.Next(100, 100000);
                        imgsDb = db.image.Where(i => i.imgid == imgNumber).DefaultIfEmpty().First();

                    }
                    //END random image number

                    db.image.Add(new Models.image()
                    {
                        id = x,
                        imgid = imgNumber,
                        picture = byteFile

                    });

                    db.SaveChanges();
                }


                if (img1 != null)
                {
                    int contentLengthImg1 = img1.ContentLength;

                    byte[] byteFile = new byte[contentLengthImg1];

                    img1.InputStream.Read(byteFile, 0, contentLengthImg1);

                    //random image number
                    Random rand = new Random();
                    int imgNumber = 0;
                    imgNumber = rand.Next(100, 100000);
                    var imgsDb = db.image.Where(i => i.imgid == imgNumber).DefaultIfEmpty().First();
                    while (imgsDb != null)
                    {
                        imgNumber = rand.Next(100, 100000);
                        imgsDb = db.image.Where(i => i.imgid == imgNumber).DefaultIfEmpty().First();

                    }
                    //END random image number

                    db.image.Add(new Models.image()
                    {
                        id = x,
                        imgid = imgNumber,
                        picture = byteFile

                    });

                    db.SaveChanges();
                }

                if (img2 != null)
                {
                    int contentLengthImg2 = img2.ContentLength;

                    byte[] byteFile = new byte[contentLengthImg2];

                    img2.InputStream.Read(byteFile, 0, contentLengthImg2);

                    //random image number
                    Random rand = new Random();
                    int imgNumber = 0;
                    imgNumber = rand.Next(100, 100000);
                    var imgsDb = db.image.Where(i => i.imgid == imgNumber).DefaultIfEmpty().First();
                    while (imgsDb != null)
                    {
                        imgNumber = rand.Next(100, 100000);
                        imgsDb = db.image.Where(i => i.imgid == imgNumber).DefaultIfEmpty().First();

                    }
                    //END random image number

                    db.image.Add(new Models.image()
                    {
                        id = x,
                        imgid = imgNumber,
                        picture = byteFile

                    });

                    db.SaveChanges();
                }


                if (img3 != null)
                {
                    int contentLengthImg3 = img3.ContentLength;

                    byte[] byteFile = new byte[contentLengthImg3];

                    img3.InputStream.Read(byteFile, 0, contentLengthImg3);

                    //random image number
                    Random rand = new Random();
                    int imgNumber = 0;
                    imgNumber = rand.Next(100, 100000);
                    var imgsDb = db.image.Where(i => i.imgid == imgNumber).DefaultIfEmpty().First();
                    while (imgsDb != null)
                    {
                        imgNumber = rand.Next(100, 100000);
                        imgsDb = db.image.Where(i => i.imgid == imgNumber).DefaultIfEmpty().First();

                    }
                    //END random image number

                    db.image.Add(new Models.image()
                    {
                        id = x,
                        imgid = imgNumber,
                        picture = byteFile

                    });

                    db.SaveChanges();
                }

                //END UPLOAD FILES//

                if (myName.ToString() != string.Empty)
                
                { 
                    ViewBag.successfull = "block";
                    string colorName = color1.ToString();
                    db.third_party.Add(new Models.third_party()
                    {
                        emergencyReportId = x,
                        driverName = myName,
                        driverId = driverID,
                        phoneNumber = driverPhone,
                        drivingLicenseNumber = driverLicenseNum,
                        address = address1.ToString(),
                        carOwnerName = carOwnerName,
                        carOwnerId = carOwnerId,
                        licensePlateNumber =carLicensePlate,
                        carCategory = carCategory,
                        carModel = carModel,
                        carColor = colorName,
                        yearOfManufacture = Convert.ToInt32(year),
                        insuranceCompanyName = compName,
                        insurancePolicyNumber = policyNum,
                        insuranceAgentName = agentName,
                        insuranceAgentPhone = agentPhone
                    });
                }
                
                db.SaveChanges();
            }

            TempData["reportNotifFlag"] = 1;

            // Truck driver algorithm //

            var db1 = new Models.rtesEntities1();
                if (checkBox1 == true)// Checks if need towing service
                {
                    Session["AlgFlag"] = 1;
                    Session["clientLng"] = lng;
                    Session["clientLat"] = lat;

                    var driver = db1.truckDriver.Where(t => t.workStatus == true).ToList();

                    var list = from v in db1.truckDriver
                               join e in db1.taskList on v.abstractUserId equals e.truckDriverId
                               where v.workStatus == true && v.TasksCounter < 3
                               select new truckDriverList { driverId = v.abstractUserId, lan = v.Latitude, lng = v.Longitude, tasksCount=(int)v.TasksCounter , cargo=(int)v.cargo, prior1 =(int)v.priority1, prior2 = (int)v.priority2, prior3= (int)v.priority3, prior4 = (int)v.priority4, prior5 = (int)v.priority5, prior6 = (int)v.priority6, prior1Role = v.priority1Role, prior2Role = v.priority2Role, prior3Role = v.priority3Role, prior4Role = v.priority4Role, prior5Role = v.priority5Role, prior6Role = v.priority6Role };

                    int listCnt = list.Count(); 

                    Session["driversListSize"] = list.Count();  // list size

                    Models.truckDriverList[] driversListModel = new Models.truckDriverList[listCnt];
                    

                    Session["driversList"] = list;  // the drivers list from db

                    int i = 0;
                    foreach(var y in list)
                    {
                        driversListModel[i] = y;
                    
                        var list2 = from t in db1.taskList
                                    join e in db1.emergencyReport on t.reportId equals e.reportID
                                    where t.truckDriverId == y.driverId
                                    select new { lat = e.Latitude , lng = e.Longitude, reportId = e.reportID , latDestin = e.latDest, lngDestin = e.lngDest};

                    //get coordinates of each task for each selected truck driver
                    //insert data to model

                    driversListModel[i].tasksLat = new string[2];
                    driversListModel[i].tasksLng = new string[2];
                    driversListModel[i].reportId = new string[2];
                    driversListModel[i].tasksLatDest = new string[2];
                    driversListModel[i].tasksLngDest = new string[2];

                    driversListModel[i].tasksLat[0] = "0";
                    driversListModel[i].tasksLng[0] = "0";
                    driversListModel[i].tasksLat[1] = "0";
                    driversListModel[i].tasksLng[1] = "0";
                    driversListModel[i].reportId[1] = "0";
                    driversListModel[i].reportId[0] = "0";
                    driversListModel[i].tasksLatDest[0] = "0";
                    driversListModel[i].tasksLatDest[1] = "0";
                    driversListModel[i].tasksLngDest[1] = "0";
                    driversListModel[i].tasksLngDest[0] = "0";


                    int j = 0;
                        foreach(var d in list2)
                        {
                            driversListModel[i].tasksLat[j] = d.lat;
                            driversListModel[i].tasksLng[j] = d.lng;
                            driversListModel[i].reportId[j] = d.reportId.ToString();
                            driversListModel[i].tasksLatDest[j] = d.latDestin;
                            driversListModel[i].tasksLngDest[j] = d.lngDestin;
                        j++;
                        }

                    i++;
                    }


                //remove duplicates - fixed & final array
                Models.truckDriverList[] driversListModelDistinct = driversListModel.GroupBy(x => x.driverId).Select(x => x.First()).ToArray();


                Session["driverFlagModel"] = 1;

                return PartialView("bufferView", driversListModelDistinct);
                
            }
            return RedirectToAction("client", "client");

            // END Truck driver algorithm //


        }
       

        //Bind the data from client - javascript - generated by algorithm - to C# - server side & set to DB.
        [HttpPost]
        public void algorithmFunc(int driverId, int reportId, String distance, int prior1, int prior2, int prior3, int prior4, int prior5, int prior6, String prior1Role, String prior2Role, String prior3Role, String prior4Role, String prior5Role, String prior6Role)  //Truck drivers assigning algorithm
        {

            var db = new Models.rtesEntities1();   //create db instance

            var truckDriverTable = db.truckDriver.Where(i => i.abstractUserId == driverId).FirstOrDefault();

            
            truckDriverTable.TasksCounter = truckDriverTable.TasksCounter + 1;
            truckDriverTable.priority1 = prior1;
            truckDriverTable.priority1Role = prior1Role;
            truckDriverTable.priority2 = prior2;
            truckDriverTable.priority2Role = prior2Role;
            truckDriverTable.priority3 = prior3;
            truckDriverTable.priority3Role = prior3Role;
            truckDriverTable.priority4 = prior4;
            truckDriverTable.priority4Role = prior4Role;
            truckDriverTable.priority5 = prior5;
            truckDriverTable.priority5Role = prior5Role;
            truckDriverTable.priority6 = prior6;
            truckDriverTable.priority6Role = prior6Role;

            var y = 0;
            var maxId = db.taskList.DefaultIfEmpty().Max(r => r == null ? 0 : r.taskId); //get the max report Id
            y= Convert.ToInt32(maxId.ToString());//convert type of string to int
            y = y + 1;

            db.taskList.Add(new Models.taskList()
            {
                truckDriverId = driverId,
                reportId = x,
                taskId = y,
                status=0
            });

            db.SaveChanges();   //save to db

        }


        public ActionResult deleteMessages(int messageNum) // delete message function
        {
            using (var db = new Models.rtesEntities1())
            {
                var deleteMessage = db.messagesTable.Where(i => i.msgNum == messageNum).FirstOrDefault();
                db.messagesTable.Remove(deleteMessage);
                db.SaveChanges();
            }
            TempData["delete"] = 1;
            return RedirectToAction("client", "client");
        }


    }

}