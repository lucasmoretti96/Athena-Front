using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Olimpia_Front_End
{
    public partial class Maquinas : System.Web.UI.Page
    {
        Models.getIdCompany get = new Models.getIdCompany();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Alimentando as DropDownLists da página
            feedDdlSala();
            feedDdlSalaEdit();
            feedDdlEditMachine();
            feedDdlDelMachine();

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
                    html.Append("<img src='img/laptop.png' class='img-card'>");
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
                PlaceHolder3.Controls.Add(new Literal { Text = html.ToString() });
            }

        }

        private DataTable GetData()
        {
            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConn))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT Machines.idMachines 'Código da Máquina', Machines.CpuName 'Info. Processador', Machines.HdTotal 'HD Total', Machines.RamTotal 'Memória RAM Total' , Machines.IP, Class.Class 'Sala' FROM Machines, Class WHERE Machines.idClass=Class.idClass and Machines.idCompany='{get.getSessionidCompany()}'"))
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

        #region Editando Máquinas
        protected void btnEditMachine_Click(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();

            using (SqlConnection conn102 = new SqlConnection(strConn))
            {
                conn102.Open();
                using (SqlCommand cmdMachineEdit = new SqlCommand("UPDATE Machines SET idClass=@idEditClass WHERE idMachines=@idMachinesEdit", conn102))
                {
                    cmdMachineEdit.Parameters.AddWithValue("@idEditClass", ddlSalaEdit.Text);
                    cmdMachineEdit.Parameters.AddWithValue("@idMachinesEdit", ddlEditMachine.Text);
                    cmdMachineEdit.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Máquina editada com sucesso!')", true);

                }
            }
            repopularDataTable();
        }
        #endregion

        #region Excluindo Máquinas
        protected void btnDeleteMachine_Click(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();

            using (SqlConnection conn103 = new SqlConnection(strConn))
            {

                conn103.Open();

                // Cria um comando para excluir o registro cujo Id é o selecionado
                using (SqlCommand cmdDelMachine = new SqlCommand("DELETE FROM Machines WHERE idMachines = @idDelMachines", conn103))
                {
                    // Esse valor poderia vir de qualquer outro lugar, como uma TextBox...
                    cmdDelMachine.Parameters.AddWithValue("@idDelMachines", ddlDelMachine.Text);

                    cmdDelMachine.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Máquina excluída com sucesso!!')", true);

                }

                repopularDataTable();
            }
        }
        #endregion

        #region Filtro Máquinas
        protected void btnViewMachine_Click(object sender, EventArgs e)
        {
            string selecionado = ddlFiltroMaquina.SelectedValue.ToString();
            if (selecionado == "1")
            {
                Response.Redirect("ByClass.aspx");
            }
            else if (selecionado == "2")
            {
                Response.Redirect("ByUser.aspx");
            }
            else if (selecionado == "3")
            {
                Response.Redirect("ByCPU.aspx");
            }
           
        }
        #endregion

        #region Cadastrando uma nova Máquina

        protected void btnAddMachine_Click(object sender, EventArgs e)
        {
            if (txtidMachine.Text == "" || ddlSala.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Por favor preencha os campos necessários')", true);
            }
            else
            {
                string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();
                SqlConnection conn1 = new SqlConnection(strConn);
                SqlCommand valid = new SqlCommand($"SELECT idMachines FROM MACHINES WHERE idMachines='{txtidMachine.Text}'", conn1);
                valid.CommandType = System.Data.CommandType.Text;
                SqlDataReader reader;
                try
                {
                    conn1.Open();
                    reader = valid.ExecuteReader();

                    if (reader.Read() == false)
                    {


                        string strConnect = ConfigurationManager.ConnectionStrings["MyDB"].ToString();
                        using (SqlConnection connect = new SqlConnection(strConn))
                        {
                            connect.Open();

                            using (SqlCommand cmdAddMachine = new SqlCommand("INSERT INTO Machines(idMachines, idClass, idCompany) " +
                          "VALUES(@idMachines, @idClass, @idCompany)", connect))
                            {
                                cmdAddMachine.Parameters.AddWithValue("@idMachines", txtidMachine.Text);
                                cmdAddMachine.Parameters.AddWithValue("@idClass", ddlSala.Text);
                                int idCompany = get.getSessionidCompany();
                                cmdAddMachine.Parameters.AddWithValue("@idCompany", idCompany);


                                cmdAddMachine.ExecuteNonQuery();
                                connect.Close();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Máquina cadastrada com sucesso!!')", true);
                            }
                        }
                        repopularDataTable();
                        //getNumbMachines();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Código de Máquina já utilizado!')", true);
                        conn1.Close();

                        repopularDataTable();
                    }



                }
                catch (Exception ex)
                {
                    this.lblMensagem.Text = "Deu erro! " + ex;
                }

            }
        }
        #endregion

        #region Método para repopular a DataTable
        public void repopularDataTable()
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
                    html.Append("<img src='img/laptop.png' class='img-card'>");
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
                PlaceHolder3.Controls.Add(new Literal { Text = html.ToString() });
            }
        }
        #endregion

        #region Alimentando a ddlEditMachine
        public void feedDdlEditMachine()
        {
            if (ddlSala.Text == "")
            {
                string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();

                using (SqlConnection conn2 = new SqlConnection(strConn))
                {

                    conn2.Open();

                    // Cria um comando para excluir o registro cujo Id é o selecionado
                    using (SqlCommand cmdAddMachine = new SqlCommand($"SELECT idMachines FROM Machines WHERE idCompany = {get.getSessionidCompany()}", conn2))
                    {

                        using (SqlDataReader reader = cmdAddMachine.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                int idMachines = reader.GetInt32(0);
                                ddlEditMachine.Items.Add(new ListItem(idMachines + ""));
                            }
                        }

                    }

                    conn2.Close();
                }
            }
        }
        #endregion

        #region Alimentando a ddlSala
        public void feedDdlSala()
        {
            if (ddlSala.Text == "")
            {
                string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();

                using (SqlConnection conn2 = new SqlConnection(strConn))
                {

                    conn2.Open();

                    // Cria um comando para excluir o registro cujo Id é o selecionado
                    using (SqlCommand cmdAddMachine = new SqlCommand($"SELECT idClass, Class FROM Class WHERE idCompany = {get.getSessionidCompany()}", conn2))
                    {

                        using (SqlDataReader reader = cmdAddMachine.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                int idClass = reader.GetInt32(0);
                                string Sala = reader.GetString(1);
                                ddlSala.Items.Add(new ListItem(Sala, idClass + ""));
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

                    using (SqlCommand cmdAddMachine = new SqlCommand($"SELECT idClass, Class FROM Class WHERE idCompany = {get.getSessionidCompany()}", conn2))
                    {

                        using (SqlDataReader reader = cmdAddMachine.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                int idClass = reader.GetInt32(0);
                                string Sala = reader.GetString(1);
                                ddlSalaEdit.Items.Add(new ListItem(Sala, idClass + ""));
                            }
                        }

                    }

                    conn2.Close();
                }
            }
        }
        #endregion

        #region Alimentando a ddlDellMachine
        public void feedDdlDelMachine()
        {
            if (ddlSala.Text == "")
            {
                string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();

                using (SqlConnection conn2 = new SqlConnection(strConn))
                {

                    conn2.Open();

                    // Cria um comando para excluir o registro cujo Id é o selecionado
                    using (SqlCommand cmdAddMachine = new SqlCommand($"SELECT idMachines FROM Machines WHERE idCompany = {get.getSessionidCompany()}", conn2))
                    {

                        using (SqlDataReader reader = cmdAddMachine.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                int idMachines = reader.GetInt32(0);
                                ddlDelMachine.Items.Add(new ListItem(idMachines + ""));
                            }
                        }

                    }

                    conn2.Close();
                }
            }
        }
        #endregion

        #region Realizando Logout
        protected void btnLogoutUsers_Click(object sender, EventArgs e)
        {
            // Invalida Sessão
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
        #endregion

        protected void btnIdMachines_Click(object sender, EventArgs e)
        {
            Session["getIdMachine"] = txtGetidMachines.Text;
            Response.Redirect("dash.aspx");
        }
    }
}