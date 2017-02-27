﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName;
        int userId;

        //check session for logged in user

        if (Session["user"] != null)  //logged in user
        {
            //show hiddent user cp fields
            loginBtn.Style["display"] = "none";
            regBtn.Style["display"] = "none";
            logoutButton.Style["display"] = "inline";  //show logout button
            

            companyPanel.Style["display"] = "inline";
            openCasesPanel.Style["display"] = "inline";
            using (var db = new rtesEntities1())
            {
                userName = Session["user"].ToString();  //read the user name
                userId = (int)(Session["uid"]);    //convert session to int - read the id
                

                //read from database
                var user = db.abstract_user.Where(i => i.id == userId).FirstOrDefault();
                
                //update user cp
                companyLabel.Text = "Company:" + " " + user.company;
                usernameLabel.Text = userName + " " + user.familyName;
                //count cases
                var userCasesCount = db.@case.Where(i => i.caseAbstractUserId == userId).Count();

                openCasesLabel.Text = "Open Cases: [" + userCasesCount + "]";

            }
        }

        else  //guest mode
        {
            //control the buttons and panels to display
            usernameLabel.Text = "Guest (please login)";
            companyLabel.Text = "Company: [Guest]";
            openCasesLabel.Text = "Open Cases: [Guest]";

            companyPanel.Style["display"] = "none";
            openCasesPanel.Style["display"] = "none";

            loginBtn.Style["display"] = "inline";
            regBtn.Style["display"] = "inline";
            logoutButton.Style["display"] = "none";
            
        }
    }

}