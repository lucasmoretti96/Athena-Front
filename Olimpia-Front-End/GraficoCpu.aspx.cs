using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;

namespace Olimpia_Front_End
{
    public partial class GraficoCpu : System.Web.UI.Page
    {
        [WebMethod]
        public static string getUltimaLeituraCpu()
        {
            Models.idMachine idMachine = new Models.idMachine();
            
            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();
            using (SqlConnection con = new SqlConnection(strConn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"SELECT TOP 1 DateTime, CpuUsage FROM CpuInf WHERE idMachines='{idMachine.getIdMachines()}' ORDER BY IDCPU DESC ", con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    return rd[0].ToString() + "@" + rd[1].ToString();
                }

            }

            return "";
        }
    }
}