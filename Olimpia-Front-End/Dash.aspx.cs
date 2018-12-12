using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace Olimpia_Front_End
{
    public partial class Dash : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
           

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
                html.Append("<table class = 'table'>");

                //Building the Header row.
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<th>");
                    html.Append(column.ColumnName);
                    html.Append("</th>");

                }

                html.Append("</tr>");

                //Building the Data rows.
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        html.Append("<td>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                    }
                    html.Append("</tr>");
                }

                //Table end.
                html.Append("</table>");

                //Append the HTML string to Placeholder.
                PlaceHolder3.Controls.Add(new Literal { Text = html.ToString() });

            }

        }

        private DataTable GetData()
        {
            string idMachine = Session["getIdMachine"].ToString();

            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConn))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT Machines.idMachines 'Código da Máquina', Machines.CpuName 'Info. Processador', Machines.HdTotal 'HD Total', Machines.RamTotal 'Memória RAM Total' , Machines.IP, Class.Class 'Sala' FROM Machines, Class WHERE Machines.idClass=Class.idClass and Machines.idCompany=1 AND idMachines='{idMachine}'"))
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
    #region Realizando Logout
    protected void btnLogoutUsers_Click(object sender, EventArgs e)
    {
        // Invalida Sessão
        Session.Abandon();
        Response.Redirect("login.aspx");
           
    }
        #endregion

        //protected void btnInfos_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("powerbi.aspx");
        //}
    }

}