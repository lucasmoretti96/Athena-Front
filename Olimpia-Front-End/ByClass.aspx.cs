using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Olimpia_Front_End.MachinesFilters
{
    public partial class ByClass : System.Web.UI.Page
    {
        Models.getIdCompany get = new Models.getIdCompany();

        protected void Page_Load(object sender, EventArgs e)
        {
            feedDdlFiltroSala();


            #region Recuperando Sessão
            // Recupera usuario da sessão
            string usuario = (string)Session["UserName"];

            // Sessão for invalida
            if (usuario == null)
            {
                Response.Redirect("login.aspx");
            }


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
            #endregion
        }
        protected void btnFiltroSala_Click(object sender, EventArgs e)
        {

            GetData();
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
            Page_Load(null, null);

        }
        #endregion



        private DataTable GetData()
        {
            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConn))
            {

                using (SqlCommand cmd = new SqlCommand($"SELECT Machines.idMachines 'Código da Máquina', Machines.CpuName 'Info. Processador', Machines.HdTotal 'HD Total', Machines.RamTotal 'Memória RAM Total' , Machines.IP, Class.Class 'Sala' FROM Machines, Class WHERE Machines.idClass=Class.idClass and Machines.idCompany='{get.getSessionidCompany()}' AND Machines.idClass='{ddlFiltroSala.Text}'"))
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

        #region Alimentando a ddlSala
        public void feedDdlFiltroSala()
        {
            if (ddlFiltroSala.Text == "")
            {
                string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();

                using (SqlConnection conn2 = new SqlConnection(strConn))
                {

                    conn2.Open();

                    // Cria um comando para excluir o registro cujo Id é o selecionado
                    using (SqlCommand cmdAddMachine = new SqlCommand($"SELECT idClass, Class FROM Class WHERE idCompany = '{get.getSessionidCompany()}'", conn2))
                    {

                        using (SqlDataReader reader = cmdAddMachine.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                int idClass = reader.GetInt32(0);
                                string Sala = reader.GetString(1);
                                ddlFiltroSala.Items.Add(new ListItem(Sala, idClass + ""));
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

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("maquinas.aspx");
        }
    }
}

