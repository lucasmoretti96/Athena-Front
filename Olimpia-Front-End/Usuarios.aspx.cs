using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Olimpia_Front_End
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected int IdUser;
        protected string UserName;
        protected string UserEmail;
        public string lblMessage;


        protected void Page_Load(object sender, EventArgs e)
        {
            feedDdlUserEdit();
            feedDdlUserDel();


            #region Recuperando Sessão
            // Recupera usuario da sessão
            string usuario = (string)Session["UserName"];

            // Sessão for invalida
            if (usuario == null)
            {
                Response.Redirect("login.aspx");
            }

            #endregion

            #region Gerando DataTable

            if (!this.IsPostBack)
            {


                //Populating a DataTable from database.
                DataTable dt = this.GetData();

                //Building an HTML string.
                StringBuilder html = new StringBuilder();

                //Table start.


                html.Append("<div class='card-deck' style='background-color: transparent'>");
                //Building the Data rows.
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<div class='col-sm-3'>");
                    html.Append("<div class='card' style='background-color: #fff'");

                    html.Append("<div class='card-body'>");
                    html.Append("<center>");
                    html.Append("<img src='img/group.png' class='img-card'>");
                    html.Append("</center>");


                    html.Append("<hr>");


                    foreach (DataColumn column in dt.Columns)
                    {

                        html.Append("<h5 class='card-title text-uppercase'>");
                        html.Append(column.ColumnName);
                        html.Append("</h5>");
                        html.Append("<p class='card-text'>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</p>");
                        html.Append("<hr>");
                    }

                    html.Append("</div>");
                    html.Append("</div>");
                }
                html.Append("</div>");


                //Append the HTML string to Placeholder.
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            }
        }

        private DataTable GetData()
        {
            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConn))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT UserName 'Nome', Email'E-mail' FROM Users where idCompany='{getSessionidCompany()}' order by UserName"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }

        }

        #endregion

        #region Cadastrando Usuário
        protected void btnCadastrarUser_Click(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();

            using (SqlConnection conn1 = new SqlConnection(strConn))
            {
                conn1.Open();

                using (SqlCommand cmdNewUser = new SqlCommand("INSERT INTO Users(UserName, CPF, Email, Password, idCompany)" +
                    "OUTPUT INSERTED.IdUsers VALUES(@UserName, @CPFUser, @EmailUser, @PwdUser, @idCompany)", conn1))
                {
                    cmdNewUser.Parameters.AddWithValue("@UserName", txtUserName.Text);
                    cmdNewUser.Parameters.AddWithValue("@CPFUser", numUserCPF.Text);
                    cmdNewUser.Parameters.AddWithValue("@EmailUser", txtUserEmail.Text);
                    cmdNewUser.Parameters.AddWithValue("@PwdUser", txtUserPwd.Text);
                    int idCompany = getSessionidCompany();
                    cmdNewUser.Parameters.AddWithValue("@idCompany", idCompany);

                    // Agora a variável id conterá o valor do campo Id do registro criado
                    int idUsers = (int)cmdNewUser.ExecuteScalar();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Usuário cadastrado com sucesso!!')", true);
                }

                repopulaCards();

            }
        }
        #endregion

        #region Editando Usuário
        protected void btnEditarUser_Click(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();


            using (SqlConnection conn2 = new SqlConnection(strConn))
            {
                conn2.Open();
                using (SqlCommand cmdUserEdit = new SqlCommand("UPDATE Users SET UserName=@UserName, Email=@EmailUser, Password=@PassUser WHERE IdUsers=@idUserEdit", conn2))
                {

                    cmdUserEdit.Parameters.AddWithValue("@UserName", txtUserNameEdit.Text);
                    cmdUserEdit.Parameters.AddWithValue("@EmailUser", txtUserEmailEdit.Text);
                    cmdUserEdit.Parameters.AddWithValue("@idUserEdit", ddlUserEdit.Text);
                    cmdUserEdit.Parameters.AddWithValue("@PassUser", txtPasswordEdit.Text);


                    cmdUserEdit.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Usuário editado com sucesso!!')", true);

                }
            }

            repopulaCards();

        }
        #endregion

        #region Deletando Usuário
        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();

            using (SqlConnection conn3 = new SqlConnection(strConn))
            {

                conn3.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE IdUsers = @idDelete", conn3))
                {
                    cmd.Parameters.AddWithValue("@idDelete", ddlUserDel.Text);
                    cmd.ExecuteNonQuery();
                }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Usuário excluído com sucesso!!')", true);
            }

            repopulaCards();
        }
        #endregion

        #region Visualização de Salas





        #endregion

        #region Método para obter o Código da Empresa
        public int getSessionidCompany()
        {
            int idCompany = 0;
            string usuario = (string)Session["UserName"];
            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();

            using (SqlConnection conn3 = new SqlConnection(strConn))
            {
                conn3.Open();

                using (SqlCommand cmdAddMachine = new SqlCommand($"SELECT Company.idCompany,  Users.idCompany FROM Company, Users WHERE UserAdmin='{usuario}' or UserName ='{usuario}'", conn3))
                {
                    using (SqlDataReader reader = cmdAddMachine.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            idCompany = reader.GetInt32(0);
                        }

                    }
                }
            }

            return idCompany;
        }
        #endregion

        #region Alimentando a ddlUserEdit
        public void feedDdlUserEdit()
        {
            if (ddlUserEdit.Text == "")
            {
                string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();

                using (SqlConnection conn2 = new SqlConnection(strConn))
                {

                    conn2.Open();

                    // Cria um comando para excluir o registro cujo Id é o selecionado
                    using (SqlCommand cmdAddMachine = new SqlCommand($"SELECT idUsers, UserName FROM Users WHERE idCompany = {getSessionidCompany()}", conn2))
                    {

                        using (SqlDataReader reader = cmdAddMachine.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                int idUsers = reader.GetInt32(0);
                                string Username = reader.GetString(1);
                                ddlUserEdit.Items.Add(new ListItem(Username, idUsers + ""));
                            }
                        }

                    }

                    conn2.Close();
                }
            }
        }
        #endregion

        #region Alimentando a ddlUserDel
        public async void feedDdlUserDel()
        {
            if (ddlUserEdit.Text == "")
            {
                string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();

                using (SqlConnection conn2 = new SqlConnection(strConn))
                {

                    conn2.Open();

                    // Cria um comando para excluir o registro cujo Id é o selecionado
                    using (SqlCommand cmdAddMachine = new SqlCommand($"SELECT idUsers, UserName FROM Users WHERE idCompany = {getSessionidCompany()}", conn2))
                    {

                        using (SqlDataReader reader = cmdAddMachine.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                int idUsers = reader.GetInt32(0);
                                string Username = reader.GetString(1);
                                ddlUserDel.Items.Add(new ListItem(Username, idUsers + ""));
                            }
                        }

                    }

                    conn2.Close();
                }
            }
        }
        #endregion

        public void repopulaCards()
        {
            if (this.IsPostBack)
            {


                //Populating a DataTable from database.
                DataTable dt = this.GetData();

                //Building an HTML string.
                StringBuilder html = new StringBuilder();

                //Table start.


                html.Append("<div class='card-deck' style='background-color: transparent'>");
                //Building the Data rows.
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<div class='col-sm-3'>");
                    html.Append("<div class='card' style='background-color: #fff'");

                    html.Append("<div class='card-body'>");
                    html.Append("<center>");
                    html.Append("<img src='img/group.png' class='img-card'>");
                    html.Append("</center>");


                    html.Append("<hr>");


                    foreach (DataColumn column in dt.Columns)
                    {

                        html.Append("<h5 class='card-title text-uppercase'>");
                        html.Append(column.ColumnName);
                        html.Append("</h5>");
                        html.Append("<p class='card-text'>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</p>");
                        html.Append("<hr>");
                    }

                    html.Append("</div>");
                    html.Append("</div>");
                }
                html.Append("</div>");


                //Append the HTML string to Placeholder.
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            }
        }

        #region Realizando Logout
        protected void btnLogoutUsers_Click(object sender, EventArgs e)
        {
            // Invalida Sessão
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
        #endregion
    }

}

