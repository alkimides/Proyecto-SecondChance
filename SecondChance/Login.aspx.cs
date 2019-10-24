using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SecondChance
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Para que el error no se vea al principio
            lblErrorMsg.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Insertamos la funcion authenticate();
            if (authenticate(txtUserName.Text, txtPassword.Text))
            {
                //Guardamos username en sesión para poder usarlo en home.aspx
                Session["username"] = txtUserName.Text.Trim();
                //Redirigimos a home.aspx si el login es correcto
                Response.Redirect("~/Home.aspx");
            }
            else //Si el login es incorrecto Error
            {
                lblErrorMsg.Text = "Usuario y/o contraseña incorrecta";
                lblErrorMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnPostbackRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registration.aspx");
        }

        private bool authenticate(string Username, string Password)
        {
            //Conectamos a la base de datos
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SecondChanceConnectionString"].ConnectionString);
            //Insertamos el procedimiento almacenado para validar la pass y el usuario
            SqlCommand cmd = new SqlCommand("SecondChance.sp_select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //Indicamos que txtUsername es el usuario y lo mismo con password
            cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
            
            con.Open();
            int codereturn = (int)cmd.ExecuteScalar();
            return codereturn == 1;
        }
    }
}