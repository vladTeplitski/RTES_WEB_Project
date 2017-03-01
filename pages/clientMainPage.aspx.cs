using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  //for stringbuilder
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class clientMainPage : System.Web.UI.Page
{
    string userName;
    int userId;

    protected void Page_Load(object sender, EventArgs e)
    {
        //init
        pswdChangeSuccess.Visible = false;
        pswdWrongPanel.Visible = false;
        emailWrongPanel.Visible = false;
        emailChangeSuccess.Visible = false;
        phoneChangeSuccess.Visible = false;

        //checkk session for logged in user

        if (Session["user"] != null)  //logged in user
        {

            using (var db = new rtesEntities1())
            {
                userName = Session["user"].ToString();  //read the user name
                userId = (int)(Session["uid"]);    //convert session to int - read the id


                //read from database
                var user = db.abstract_user.Where(i => i.id == userId).FirstOrDefault();
                var client = db.client.Where(i => i.abstractUserId == userId).DefaultIfEmpty().First(); ;

                if (client != null)  //if there is a client account
                {
                    //buttons init
                    backOperator.Style["display"] = "none"; //hide oprator navigation button

                    //read personal details fields from database
                    carCategory.Text = client.carCategory;
                    carModel.Text = client.carModel;
                    yearManufact.Text = client.carManufactureYear;
                    licensePlate.Text = client.licensePlate.ToString();
                    insuranceCompName.Text = client.insuranceCompanyName;
                    insuranceAgentName.Text = client.insuranceAgentName;
                    insuranceAgentPhone.Text = client.insuranceAgentPhoneNum.ToString();
                    insPolicyNum.Text = client.insurancePolicyNum.ToString();
                    policyExp.Text = client.policyEndDate;
                    drivingLicenseNum.Text = client.clientDrivingLicenseNumber.ToString();
                    carOwnerName.Text = client.carOwnerName;
                    carOwnerId.Text = client.carOwnerId.ToString();

                    //client welcome init
                    clientWelcome.Text = "Welcome " + "<b>"+user.name +"</b>" + " to client CP!";

                    //Emergency reports library init

                    var reportsDb = db.emergencyReport.Where(i => i.clientAbstractUserId == userId).ToList();
                   
                    if (reportsDb.Any())  //show all reports @ table
                    {  
                        System.Text.StringBuilder table = new StringBuilder();  //create StringBuilder instance for table code string
                        //create table code via StringBuilder
                        table.AppendLine("<table class=\"table table - striped\" id=\"ReportsLib\">");
                        table.AppendLine("<thead Style=\"background-color:#659FD3   \">");
                        table.AppendLine("<tr>");
                        table.AppendLine("<th>Report ID</th>");
                        table.AppendLine("<th>Case ID</th>");
                        table.AppendLine("<th>Date</th>");
                        table.AppendLine("<th>Hour</th>");
                        table.AppendLine("</tr>");
                        table.AppendLine("</thead>");
                        table.AppendLine("<tbody>");

                        foreach (var st in reportsDb)  //add row for each report
                        {
                            table.AppendLine("<tr>");
                            table.AppendLine("<td>");
                            table.AppendLine(st.reportID.ToString());  //report ID - from int to string
                            table.AppendLine("</td>");
                            table.AppendLine("<td>");
                            table.AppendLine(st.caseCaseId.ToString()); //content2
                            table.AppendLine("</td>");
                            table.AppendLine("<td>");
                            table.AppendLine(st.date); //content3
                            table.AppendLine("</td>");
                            table.AppendLine("<td>");
                            table.AppendLine(st.hour); //content4
                            table.AppendLine("</td>");
                            table.AppendLine("</tr>");

                        }

                        table.AppendLine("<tbody>");
                        table.AppendLine("</table>");  //end table assemble
                        rowsContent.Text = table.ToString();
                    }
                    else
                    {
                        repLibNotifPanel.Visible = true;
                    }



                }
                else  //if there is no client account
                {
                    noClientAccount.Visible = true;
                    repLibNotifPanel.Visible = true;
                    TableDetails2.Style["display"] = "none";

                    personalDetailsPanel.Style["display"] = "none";

                    reportButton.Attributes["href"] = "#";   //no click on New Report
                    reportButton.Attributes.Add("title", "You must be a client to open a report!");

                    backOperator.Style["display"] = "block"; //show oprator navigation button

                    clientWelcome.Text = "Welcome " + "<b>" + user.name + "</b>!" + " You are not registred as a 'client'.<br>User mode: "+ user.role;
                }
            }
        }

        else
        {
            //access page without login -> redirect to login page.
            //access only for logged in users.

            Response.Redirect("login.aspx");
        }
    }

    override protected void OnInit(EventArgs e)  //when property AutoEventWireup="false" override OnInit
    {
        this.Load += new System.EventHandler(this.Page_Load);
    }

    protected void changePswd(object sender, EventArgs e)
    {
        if (Session["user"] != null)  //logged in user
        {

            using (var db = new rtesEntities1())
            {
                var user = db.abstract_user.Where(i => i.id == userId).FirstOrDefault();
                if (changePswTxtPresent.Text == user.password)  //present password validation
                {
                    user.password = changePswNew.Text; //change the password in db
                    
                    pswdWrongPanel.Visible = false;
                    pswdChangeSuccess.Visible = true;

                    clientWelcome.Text = "Dear " + "<b>" + user.name + "</b>!";
                    clientOps.Text = "Password notification:";

                    db.SaveChanges();  //update database with the changes made
                }
                else
                {
                    clientWelcome.Text = "Dear " + "<b>" + user.name + "</b>! There was a mistake!";
                    clientOps.Text = "Password notification:";
                    pswdWrongPanel.Visible = true;
                }
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }



    protected void changeEmail(object sender, EventArgs e)
    {
        if (Session["user"] != null)  //logged in user
        {

            using (var db = new rtesEntities1())
            {
                var user = db.abstract_user.Where(i => i.id == userId).FirstOrDefault();
                if (presentEmailBox.Text == user.email)  //present password validation
                {
                    user.email = newEmailBox.Text; //change the password in db
                    clientWelcome.Text = "Dear " + "<b>" + user.name + "</b>!";
                    clientOps.Text = "Email notification:";
                    emailWrongPanel.Visible = false;
                    emailChangeSuccess.Visible = true;
                    db.SaveChanges();  //update database with the changes made
                }
                else
                {
                    clientWelcome.Text = "Dear " + "<b>" + user.name + "</b>!! There was a mistake!";
                    clientOps.Text = "Email notification:";
                    emailWrongPanel.Visible = true;
                }

            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }


    protected void changePhone(object sender, EventArgs e)
    {
        if (Session["user"] != null)  //logged in user
        {

            using (var db = new rtesEntities1())
            {
                var user = db.abstract_user.Where(i => i.id == userId).FirstOrDefault();
                user.userPhoneNumber = newPhoneBox.Text;
                clientWelcome.Text = "Dear " + "<b>" + user.name + "</b>!";
                clientOps.Text = "Phone number notification:";
                phoneChangeSuccess.Visible = true;
                db.SaveChanges();  //update database with the changes made
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
}