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
                    
                    try
                    {
                    //Creamos la conexión
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SecondChanceConnectionString"].ConnectionString);
                    con.Open();
                    //Insertamos el procedimiento almacenado sp_Insert
                    SqlCommand cmd = new SqlCommand("SecondChance.sp_Insert", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Metemos todos los datos con sus correspondientes valores
                        cmd.Parameters.AddWithValue("@UserID", 0);
                        cmd.Parameters.AddWithValue("@First_Name", txtFirstName.Text.ToString());
                        cmd.Parameters.AddWithValue("@Last_Name", txtLastName.Text.ToString());
                        cmd.Parameters.AddWithValue("@Birth_Date", txtBirthDate.Text.ToString());
                        cmd.Parameters.AddWithValue("@Phone_Number", txtPhoneNumber.Text.ToString());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString());
                        cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@Adress", txtAdress.Text.ToString());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.ToString());
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.ToString());

                        //Si se registra correctamente nos lleva a login.aspx para poder acceder a la pagina
                        int codereturn = (int)cmd.ExecuteScalar();
                        Response.Redirect("~/Login.aspx");


                     }
                       catch(Exception ex)
                        {
                    //Creamos una excepcion por si falla el registro:
                        lblMsg.Text = "El usuario ya existe";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        }
                    
                   
                   


                }
                
           
            
        }
    }
}
