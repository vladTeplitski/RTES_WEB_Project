using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class operatorPage : System.Web.UI.Page
{
    string userName;
    int userId;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //init


            //checkk session for logged in user

            if (Session["user"] != null)  //logged in user
        {

            using (var db = new rtesEntities1())
            {
                userName = Session["user"].ToString();  //read the user name
                userId = (int)(Session["uid"]);    //convert session to int - read the id


                //fill reports table from DB
                var reportsDb = db.emergencyReport.ToList();
                Repeater1.DataSource = reportsDb;
                Repeater1.DataBind();

                //fill users table from DB
                var users = db.abstract_user.ToList();
                Repeater2.DataSource = users;
                Repeater2.DataBind();

                //clients list for dropdown - from DB

                if (!IsPostBack)
                {  //!IsPostBack fixes problem of first option choose by default
                    var clients = db.abstract_user.Where(i => i.role == "Client");


                    dropList.DataSource = clients.ToList();
                    dropList.DataTextField = "id";
                    dropList.DataValueField = "id";
                    dropList.DataBind();
                }

            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
        }
    }

    override protected void OnInit(EventArgs e)  //when property AutoEventWireup="false" override OnInit
    {
        this.Load += new System.EventHandler(this.Page_Load);
    }


    protected void sendMessage(object sender, EventArgs e)
    {
        if (Session["user"] != null)  //logged in user
        {

            using (var db = new rtesEntities1())
            {
                int val = Int32.Parse(dropList.SelectedValue);  //get selected value
                                                                //var client = db.client.Where(i => i.abstractUserId == val).FirstOrDefault();

                //generate message number - key in db

                Random rand = new Random();
                int msgNumber = 0;
                msgNumber = rand.Next(1000, 100000);
                var msgsDb = db.messagesTable.Where(i => i.msgNum == msgNumber).DefaultIfEmpty().First();
                while (msgsDb!=null)
                {
                    msgNumber = rand.Next(1000, 100000);
                    msgsDb = db.messagesTable.Where(i => i.msgNum == msgNumber).DefaultIfEmpty().First();

                }

                messagesTable msg = new messagesTable
                {
                    msgNum = msgNumber,    //add the new message generated number
                    userID = val,
                    content = Textbox1.Text.ToString(),
                    date = DateTime.Now.ToString()  //get current date
                };
                db.messagesTable.Add(msg); //add new row to db
                db.SaveChanges();

            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void rowClick(Object Sender, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "click":
                InfoLable.Style["display"] = "block";
                using (var db = new rtesEntities1()) {
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

                    moreInfoLabel.Text = list.ToString();
                break;
                }
        }
    }

    protected void closeFrame(object sender, EventArgs e)  //button x
    {
        InfoLable.Style["display"] = "none";

    }

    protected void closeClientList(object sender, EventArgs e)  //button x
    {
        userListLable.Style["display"] = "none";

    }


    protected void clientListClick(Object Sender, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "click":
                userListLable.Style["display"] = "block";
                using (var db = new rtesEntities1())
                {
                    int x = Int32.Parse(e.CommandArgument.ToString());
                    var user = db.abstract_user.Where(i => i.id == x).FirstOrDefault();

                    System.Text.StringBuilder list = new StringBuilder();

                    list.AppendLine("<table class=\"table table-bordered\">");
                    list.AppendLine("<tr><td>User ID:</td>");
                    list.AppendLine("<td>");
                    list.AppendLine(user.id.ToString());
                    list.AppendLine("</td></tr>");
                    list.AppendLine("<tr><td>Name:</td>");
                    list.AppendLine("<td>");
                    list.AppendLine(user.name);
                    list.AppendLine("</td></tr>");
                    list.AppendLine("<tr><td>Family Name:</td>");
                    list.AppendLine("<td>");
                    list.AppendLine(user.familyName);
                    list.AppendLine("</td></tr>");
                    list.AppendLine("<tr><td>Email:</td>");
                    list.AppendLine("<td>");
                    list.AppendLine(user.email);
                    list.AppendLine("</td></tr>");
                    list.AppendLine("<tr>");
                    list.AppendLine("<tr><td>Address:</td>");
                    list.AppendLine("<td>");
                    list.AppendLine(user.address);
                    list.AppendLine("</td></tr>");
                    list.AppendLine("<tr><td>Gender:</td>");
                    list.AppendLine("<td>");
                    list.AppendLine(user.gender);
                    list.AppendLine("</td></tr>");
                    list.AppendLine("<tr><td>Role:</td>");
                    list.AppendLine("<td>");
                    list.AppendLine(user.role);
                    list.AppendLine("</td></tr>");
                    list.AppendLine("<tr><td>Company:</td>");
                    list.AppendLine("<td>");
                    list.AppendLine(user.company);
                    list.AppendLine("</td></tr>");
                    list.AppendLine("<tr><td>Phone:</td>");
                    list.AppendLine("<td>");
                    list.AppendLine(user.userPhoneNumber);
                    list.AppendLine("</td></tr>");
                    list.AppendLine("</table>");

                    clientListLabel.Text = list.ToString();
                    break;
                }
        }
    }



}