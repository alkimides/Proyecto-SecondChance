using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecondChance
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Guardamos sesión en un label
            lblUserLoginDetails.Text = "Username: " + Session["Username"];
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //Logout y a inicio de sesión
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}