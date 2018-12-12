using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;

namespace Olimpia_Front_End
{
    public partial class GraficoRam : System.Web.UI.Page
    {

        [WebMethod]
        public static string getUltimaLeituraRam()
        {
            Models.idMachine idMachine = new Models.idMachine();

            string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();
            using (SqlConnection con = new SqlConnection(strConn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"SELECT TOP 1 (RamMemoryInf.RamAvailable/1024)/1024, (RamMemoryInf.RamUsage/1024)/1024 FROM Machines, RamMemoryInf WHERE Machines.idMachines=RamMemoryInf.idMachines and mACHINES.idMachines='{idMachine.getIdMachines()}' ORDER BY IdRamMemory DESC", con);
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