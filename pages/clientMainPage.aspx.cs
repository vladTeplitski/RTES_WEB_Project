using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class clientMainPage : System.Web.UI.Page
{
    string userName;
    int userId;

    protected void Page_Load(object sender, EventArgs e)
    {
        vladLabel.Text = "SERVER WORKSSS!";
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
                }
                else  //if there is no client account
                {
                    noClientAccount.Visible = true;
                    TableDetails2.Style["display"] = "none";
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


}