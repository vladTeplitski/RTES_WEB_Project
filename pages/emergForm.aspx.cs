using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class emergForm : System.Web.UI.Page
{
    string userName;
    int userId;
    string date1;
    string hour1;
    int x;
    int check;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user"] != null)  //logged in user
        {

            using (var db = new rtesEntities1())
            {
                userName = Session["user"].ToString();  //read the user name
                userId = (int)(Session["uid"]);    //convert session to int - read the id


                //read from database
                var user = db.abstract_user.Where(i => i.id == userId).FirstOrDefault();
                var client = db.client.Where(i => i.abstractUserId == userId).DefaultIfEmpty().First(); ;

                //shai
                DateTime now = DateTime.Now;
                date1 = now.ToString("dd.MM.yyyy");
                // date.Text = " "+now.ToString("dd.MM.yyyy");
                date.Text = " " + date1;
                hour1 = now.ToString("hh:mm tt");
                hour.Text = " " + hour1;


                if (client != null)  //if there is a client account
                {
                    //buttons init

                    //read personal details fields from database
                    carCategory2.Text = client.carCategory;
                    carModel2.Text = client.carModel;
                    yearManufact2.Text = client.carManufactureYear;
                    licensePlate2.Text = client.licensePlate.ToString();
                    insuranceCompName2.Text = client.insuranceCompanyName;
                    insuranceAgentName2.Text = client.insuranceAgentName;
                    insuranceAgentPhone2.Text = client.insuranceAgentPhoneNum.ToString();
                    insPolicyNum2.Text = client.insurancePolicyNum.ToString();
                    policyExp2.Text = client.policyEndDate;
                    drivingLicenseNum2.Text = client.clientDrivingLicenseNumber.ToString();
                    carOwnerName2.Text = client.carOwnerName;
                    carOwnerId2.Text = client.carOwnerId.ToString();


                }
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }





    //shai
    protected void send_Details_Func(object sender, EventArgs e)
    {
        if (Session["user"] != null)  //logged in user
        {
            using (var db = new rtesEntities1())
            {
                userName = Session["user"].ToString();  //read the user name
                userId = (int)(Session["uid"]);    //convert session to int - read the id
                                                   // Create a new Order object.

                var maxId = db.emergencyReport.DefaultIfEmpty().Max(r => r == null ? 0 : r.reportID); //get the max report Id
                x = Convert.ToInt32(maxId.ToString());//convert type of string to int
                x = x + 1;
                if (CheckBox1.Checked)
                {
                    check = 1;
                    //case1.callForTowing = 1;
                }

                db.emergencyReport.Add(new emergencyReport { reportID = x, clientAbstractUserId = userId, date = date1, hour = hour1, callForTowing = (byte)check, comments = TextArea1.Text,location = location1.Text, towing_destination=towDest.Text, accident_witness_name=witName.Text});
                if (driver_name.Text != string.Empty)
                {

                    string colorName = color1.Value;
                    db.third_party.Add(new third_party
                    {
                        emergencyReportId = x,
                        driverName = driver_name.Text,
                        driverId = Convert.ToInt32(driver_ID.Text),
                        phoneNumber = Convert.ToInt32(phoneNum.Text),
                        drivingLicenseNumber = Convert.ToInt32(licenseNum.Text),
                        address = address1.Text,
                        carOwnerName = car_ownerName.Text,
                        carOwnerId = Convert.ToInt32(car_ownerID.Text),
                        licensePlateNumber = Convert.ToInt32(license_plateNum.Text),
                        carCategory = carCategory.Text,
                        carModel = carModel.Text,
                        carColor = colorName,
                        yearOfManufacture = Convert.ToInt32(year.Text),
                        insuranceCompanyName = insuranceCompanyN.Text,
                        insurancePolicyNumber = Convert.ToInt32(insurancePolicyNum.Text),
                        insuranceAgentName = insuranceAgentNa.Text,
                        insuranceAgentPhone = Convert.ToInt32(insuranceAgentPhone.Text)
                    });
                }

                shay.Visible = false;
                caseId.Text = Convert.ToString(x);
                submitDetails.Visible = true;
                db.SaveChanges();

            }

        }
    }


    override protected void OnInit(EventArgs e)  //when property AutoEventWireup="false" override OnInit
    {
        this.Load += new System.EventHandler(this.Page_Load);
    }
}