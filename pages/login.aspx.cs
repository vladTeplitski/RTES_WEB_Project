using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void login_Func(object sender, EventArgs e)
    {

        using (var db = new rtesEntities1())
        {
            var user = db.abstract_user.Where(i => i.name == lgUser.Text && i.password == lgPass.Text).FirstOrDefault();
            if (user == null)
            {
                pnlMessage.Visible = true;
            }
            else
            {
                Session["user"] = user.name;
                Session["uid"] = user.id;
                //navigation to pages
                if (user.role == "Operator")
                {
                    Response.Redirect("operatorPage.aspx");
                }
                else if (user.role == "Client")
                {
                    Response.Redirect("clientMainPage.aspx");
                }
                else
                {
                    Response.Redirect("../homePage.aspx");
                }
            }
        }
    }



}