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

        //check session for logged in user

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
                    clientWelcome.Text = "Welcome " + "<b>" + user.name + "</b>" + " to client CP!";

                    //init messages

                    var msgs = db.messagesTable.Where(i => i.userID == userId).OrderBy(a => a.date).ToList();
                    var cnt = db.messagesTable.Where(i => i.userID == userId).Count();
                    RepeaterMsgs.DataSource = msgs;
                    RepeaterMsgs.DataBind();
                    if (cnt == 0)   //if no messages
                    {
                        noMessages.Visible = true;
                        RepeaterMsgs.Visible = false;
                    }


                    //Emergency reports library init

                    var reportsDb = db.emergencyReport.Where(i => i.clientAbstractUserId == userId).ToList();

                    if (reportsDb.Any())  //show all reports @ table
                    {
                        //fill reports table from DB using repeater
                        RepeaterClientRep.DataSource = reportsDb;
                        RepeaterClientRep.DataBind();
                    }
                    else
                    {
                        repLibNotifPanel.Visible = true;
                    }

                }
                else  //if there is no client account
                {
                    noMsgAlertanel.Visible = true;  //no messages available
                    messagesMain.Style["display"] = "none";
                    noClientAccount.Visible = true;
                    repLibNotifPanel.Visible = true;
                    TableDetails2.Style["display"] = "none";

                    personalDetailsPanel.Style["display"] = "none";

                    reportButton.Attributes["href"] = "#";   //no click on New Report
                    reportButton.Attributes.Add("title", "You must be a client to open a report!");

                    clientWelcome.Text = "Welcome " + "<b>" + user.name + "</b>!" + " You are not registred as a 'client'.<br>User mode: " + user.role;
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
    
    protected void clientRepRowClick(Object Sender, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "click":
                clientRepContainer.Style["display"] = "block";
                using (var db = new rtesEntities1())
                {
                    int x = Int32.Parse(e.CommandArgument.ToString());
                    var reportsDb = db.emergencyReport.Where(i => i.reportID == x).FirstOrDefault();

                    System.Text.StringBuilder list = new StringBuilder();

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

                    clientRepLabel.Text = list.ToString();
                    break;
                }
        }
    }

    protected void closeClientRep(object sender, EventArgs e)  //button x
    {
        clientRepContainer.Style["display"] = "none";

    }

    protected void delMessage(Object Sender, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "click":

                using (var db = new rtesEntities1())
                {
                    int x = Int32.Parse(e.CommandArgument.ToString());
                    var msg = db.messagesTable.Where(i => i.msgNum == x).FirstOrDefault();

                    db.messagesTable.Remove(msg);
                    db.SaveChanges();

                    //init messages again
                    var msgs = db.messagesTable.Where(i => i.userID == userId).OrderBy(a => a.date).ToList();
                    var cnt = db.messagesTable.Where(i => i.userID == userId).Count();
                    RepeaterMsgs.DataSource = msgs;
                    RepeaterMsgs.DataBind();
                    if (cnt == 0)   //if no messages
                    {
                        noMessages.Visible = true;
                        RepeaterMsgs.Visible = false;
                    }


                    break;
                }
        }
    }
}