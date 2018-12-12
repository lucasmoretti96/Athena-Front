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
    public partial class Salas : System.Web.UI.Page
    {
        private int countClass;

        public void addNumClass()
        {
            countClass = countClass + 1;

        }

        public int getNumClass()
        {
            return countClass;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Alimentando as DropDownLists da página

            feedDdlUserSala();
            feedDdlUserSalaEdit();
            feedDdlSalaEdit();
            feedDdlSalaDel();



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
                    html.Append("<img src='img/door.png' class='img-card'>");
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
                PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });
            }
        }



        private DataTable GetData()
        {
            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConn))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT Class.Class 'Nome da Sala', Class.NumberOfMachines 'N° de Máquinas', Users.UserName 'Responsável' FROM Class, Users WHERE Users.idUsers=Class.idUsers and Class.idCompany='{getSessionidCompany()}'"))
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

        #region Excluindo Salas
        protected void btnDeleteClass_Click(object sender, EventArgs e)
        {


            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();

            using (SqlConnection conn3 = new SqlConnection(strConn))
            {

                conn3.Open();

                // Cria um comando para excluir o registro cujo Id é o selecionado
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Class WHERE idClass = @idDelete", conn3))
                {
                    // Esse valor poderia vir de qualquer outro lugar, como uma TextBox...
                    cmd.Parameters.AddWithValue("@idDelete", ddlSalaDel.Text);

                    cmd.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sala excluída com sucesso!')", true);

                }

                repopulaCards();
            }
        }
        #endregion

        #region Criando Salas
        protected void btnInsertClass_Click(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();

            using (SqlConnection conn6 = new SqlConnection(strConn))
            {
                conn6.Open();

                using (SqlCommand cmdNewClass = new SqlCommand("INSERT INTO Class(Class, IdUsers, idCompany)" +
                    "OUTPUT INSERTED.idClass VALUES(@ClassName, @IdUser, @idCompany)", conn6))
                {
                    cmdNewClass.Parameters.AddWithValue("@ClassName", txtClassName.Text);
                    cmdNewClass.Parameters.AddWithValue("@IdUser", ddlUserSala.Text);
                    int idCompany = getSessionidCompany();
                    cmdNewClass.Parameters.AddWithValue("@idCompany", idCompany);

                    // Agora a variável id conterá o valor do campo Id do registro criado
                    int idClass = (int)cmdNewClass.ExecuteScalar();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sala cadastrada com sucesso!')", true);

                }

                repopulaCards();
            }
        }
        #endregion

        #region Editando Salas
        protected void btnEditClass_Click(object sender, EventArgs e)
        {

            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();


            using (SqlConnection conn12 = new SqlConnection(strConn))
            {
                conn12.Open();
                using (SqlCommand cmdClassEdit = new SqlCommand("UPDATE Class SET Class=@EditClassName, IdUsers=@EditUserid WHERE idClass=@idClassEdit", conn12))
                {
                    cmdClassEdit.Parameters.AddWithValue("@EditClassName", txtClassNameEdit.Text);
                    cmdClassEdit.Parameters.AddWithValue("@EditUserId", ddlUserSalaEdit.Text);

                    cmdClassEdit.Parameters.AddWithValue("@idClassEdit", ddlSalaEdit.Text);

                    cmdClassEdit.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sala editada com sucesso!')", true);


                }
            }


            repopulaCards();
        }
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

        #region Alimentando a ddlUserSala
        public void feedDdlUserSala()
        {
            if (ddlUserSala.Text == "")
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
                                ddlUserSala.Items.Add(new ListItem(Username, idUsers + ""));
                            }
                        }

                    }

                    conn2.Close();
                }
            }
        }
        #endregion

        #region Alimentando a ddlUserSalaEdit
        public void feedDdlUserSalaEdit()
        {
            if (ddlUserSalaEdit.Text == "")
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
                                ddlUserSalaEdit.Items.Add(new ListItem(Username, idUsers + ""));
                            }
                        }

                    }

                    conn2.Close();
                }
            }
        }
        #endregion

        #region Alimentando a ddlSalaEdit
        public void feedDdlSalaEdit()
        {
            if (ddlSalaEdit.Text == "")
            {
                string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();

                using (SqlConnection conn2 = new SqlConnection(strConn))
                {

                    conn2.Open();

                    using (SqlCommand cmdAddMachine = new SqlCommand($"SELECT idClass, Class FROM Class WHERE idCompany = {getSessionidCompany()}", conn2))
                    {

                        using (SqlDataReader reader = cmdAddMachine.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                int idClass = reader.GetInt32(0);
                                string Class = reader.GetString(1);
                                ddlSalaEdit.Items.Add(new ListItem(Class, idClass + ""));
                            }
                        }

                    }

                    conn2.Close();
                }
            }
        }
        #endregion

        #region Alimentando a ddlSalaDel
        public void feedDdlSalaDel()
        {
            if (ddlSalaDel.Text == "")
            {
                string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();

                using (SqlConnection conn2 = new SqlConnection(strConn))
                {

                    conn2.Open();

                    using (SqlCommand cmdAddMachine = new SqlCommand($"SELECT idClass, Class FROM Class WHERE idCompany = {getSessionidCompany()}", conn2))
                    {

                        using (SqlDataReader reader = cmdAddMachine.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                int idClass = reader.GetInt32(0);
                                string Class = reader.GetString(1);
                                ddlSalaDel.Items.Add(new ListItem(Class, idClass + ""));
                            }
                        }

                    }

                    conn2.Close();
                }
            }
        }
        #endregion

        #region Método para repopular os cards
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
                    html.Append("<img src='img/door.png' class='img-card'>");
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
                PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });
            }
        }
        #endregion

        #region Obtendo qtd de máquinas

        public void getNumbMachines()
        {

            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();

            using (SqlConnection conn1 = new SqlConnection(strConn))
            {
                conn1.Open();

                int cont = 0;
                while (cont <= getNumClass())
                {
                    using (SqlCommand cmdGetNumMach = new SqlCommand($"SELECT ROW_NUMBER() OVER (ORDER BY Class.idClass) 'NUMERO', Machines.idClass, Class.idClass FROM Machines, Class WHERE Machines.idClass={cont} and Class.idClass={cont}", conn1))
                    {
                        using (SqlDataReader reader = cmdGetNumMach.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int NumMach = Convert.ToInt32(reader[0]);

                                SqlConnection conn2 = new SqlConnection(strConn);
                                conn2.Open();
                                using (SqlCommand cmdUpdate = new SqlCommand($"UPDATE CLASS SET NUMBEROFMACHINES='{NumMach}' WHERE IDCLASS='{cont}' AND IDCOMPANY='{getSessionidCompany()}'", conn2))
                                {
                                    cmdUpdate.ExecuteNonQuery();
                                }
                                conn2.Close();
                            }
                        }

                    }
                    cont++;
                }
                conn1.Close();

            }

            repopulaCards();
        }


        #region Realizando Logout
        protected void btnLogoutUsers_Click(object sender, EventArgs e)
        {
            // Invalida Sessão
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
        #endregion

        #endregion


        protected void reloadTable_Click(object sender, EventArgs e)
        {
            getNumbMachines();
            
        }

    }
}

