using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace SecondChance
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<string> countries = new List<string>();
                CultureInfo[] culture = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                foreach (CultureInfo item in culture)
                {
                    RegionInfo region = new RegionInfo(item.LCID);
                    if (!(countries.Contains(region.EnglishName)))
                    {
                        countries.Add(region.EnglishName);
                    }

                }
                countries.Sort();
                DropDownList1.DataSource = countries;
                DropDownList1.DataBind();
            }
        }

        public void ClearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtBirthDate.Text = "";
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtAdress.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        protected void btnBacktoLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
           
                if (Page.IsValid)
                {

                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SecondChanceConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into [SecondChance.users] (UserID, First_Name, Last_Name, Birth_Date, Phone_Number, Email, Adress, Password, Username) values (@UserID, @First_Name, @Last_Name, @Birth_Date, @Phone_Number, @Email, @Adress, @Password, @Username)", con);
                    String queryMax = "select max(UserID) from [SecondChance.Users]";
                    SqlCommand cmd1 = new SqlCommand(queryMax);
                    //la rama del aim
                    cmd.Parameters.AddWithValue("@UserID", cmd1.ExecuteScalar());
                    cmd.Parameters.AddWithValue("@First_Name", txtFirstName.Text.ToString());
                    cmd.Parameters.AddWithValue("@Last_Name", txtLastName.Text.ToString());
                    cmd.Parameters.AddWithValue("@Birth_Date", txtBirthDate.Text.ToString());
                    cmd.Parameters.AddWithValue("@Phone_Number", txtPhoneNumber.Text.ToString());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString());
                    cmd.Parameters.AddWithValue("@Adress", txtAdress.Text.ToString());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text.ToString());
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.ToString());
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                    Response.Write("<script>Saved Succesfully</script>");
                    ClearFields();


                }
                else
                    Response.Write("<script>Error, please try again</script>");
           
            
        }
    }
}
