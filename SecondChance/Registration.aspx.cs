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

            //Genera un Drop Down List de Paises que el Usuario debe elegir al registrarse

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
                ddlCountry.DataSource = countries;
               ddlCountry.DataBind();
            }
        }

        //Funcion para limpiar el formulario de registro una vez completado
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
                    SqlCommand cmd = new SqlCommand("insert into [SecondChance].[Users] (First_Name, Last_Name, Birth_Date, Phone_Number, Email, Adress, Password, Username) values (@First_Name, @Last_Name, @Birth_Date, @Phone_Number, @Email, @Adress, @Password, @Username)", con);
                    
                
                    
                    cmd.Parameters.AddWithValue("@First_Name", txtFirstName.Text.ToString());
                    cmd.Parameters.AddWithValue("@Last_Name", txtLastName.Text.ToString());
                    cmd.Parameters.AddWithValue("@Birth_Date", txtBirthDate.Text.ToString());
                    cmd.Parameters.AddWithValue("@Phone_Number", txtPhoneNumber.Text.ToString());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString());
                    cmd.Parameters.AddWithValue("@Country",ddlCountry.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Adress", txtAdress.Text.ToString());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text.ToString());
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.ToString());
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                    Response.Write("<script>Registrado Correctamente</script>");
                    ClearFields();
                    Response.Redirect("~/Login.aspx");


            }
                else
                    Response.Write("<script>Error, por favor, intentelo de nuevo</script>");
           
            
        }
    }
}
