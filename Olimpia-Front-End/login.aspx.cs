using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace Olimpia_Front_End
{
    public partial class login : System.Web.UI.Page

    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            Login();


        }

        private void Login()
        {
            // Recupera elementos do formulario
            string usuario = Request.Form["txtUserLogin"];
            string senha = Request.Form["txtPassLogin"];

            string conector = ConfigurationManager.ConnectionStrings["MyDB"].ToString();
            SqlConnection conn1 = new SqlConnection(conector);

            string loginAdmin = "SELECT UserAdmin, PassAdmin FROM Company WHERE UserAdmin='" + txtUserLogin.Text + "' AND PassAdmin='" + txtPassLogin.Text + "'";

            SqlCommand cmdLoginAdmin = new SqlCommand(loginAdmin, conn1);
            cmdLoginAdmin.CommandType = System.Data.CommandType.Text;
            SqlDataReader readerAdmin;
            try
            {
                conn1.Open();
                readerAdmin = cmdLoginAdmin.ExecuteReader();

                if (readerAdmin.Read())
                {
                    this.lblMensagem.Text = "Admin logado com sucesso!.";
                    Session["UserName"] = usuario;
                    Response.Redirect("Usuarios.aspx");

                    conn1.Close();
                }

                else if (readerAdmin.Read() == false)
                {
                    conn1.Close();
                    string connector = ConfigurationManager.ConnectionStrings["MyDB"].ToString();
                    SqlConnection conn2 = new SqlConnection(connector);

                    string login = "SELECT UserName, Password FROM Users WHERE UserName='" + txtUserLogin.Text + "' AND Password='" + txtPassLogin.Text + "'";
                    SqlCommand cmdLogin = new SqlCommand(login, conn2);
                    cmdLogin.CommandType = System.Data.CommandType.Text;
                    SqlDataReader readerLogin;

                    try
                    {
                        conn2.Open();
                        readerLogin = cmdLogin.ExecuteReader();

                        if (readerLogin.Read())
                        {
                            this.lblMensagem.Text = "Logado com sucesso!.";
                            Session["UserName"] = usuario;
                            Response.Redirect("Salas.aspx");

                            conn2.Close();
                        }
                        else
                        {
                            this.lblMensagem.Text = "Usuário e/ou senha incorretos.";
                        }
                    }
                    catch (Exception ex)
                    {
                        this.lblMensagem.Text = "Deu erro! " + ex;
                    }

                }

            }
            catch (Exception ex)
            {
                this.lblMensagem.Text = "Deu erro! " + ex;
            }
        }


    }


}






