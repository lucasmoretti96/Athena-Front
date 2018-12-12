using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;

namespace Olimpia_Front_End
{
    public partial class GraficoHD : System.Web.UI.Page
    {
        [WebMethod]
        public static string getUltimaLeituraHD()
        {
            Models.idMachine idMachine = new Models.idMachine();

            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();
            using (SqlConnection con = new SqlConnection(strConn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"SELECT TOP 1 (HardDiskInf.HdTotal/1024)/1024, (HardDiskInf.HdUsage/1024)/1024 FROM Machines, HardDiskInf WHERE Machines.idMachines=HardDiskInf.idMachines AND mACHINES.idMachines='{idMachine.getIdMachines()}'  ORDER BY idHD DESC", con);
                SqlDataReader rd1 = cmd.ExecuteReader();
                if (rd1.Read())
                {
                    return rd1[0].ToString() + "@" + rd1[1].ToString();
                }

            }

            return "";
        }
    }
}