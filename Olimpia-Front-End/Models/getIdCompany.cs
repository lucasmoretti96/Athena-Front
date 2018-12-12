using System.Configuration;
using System.Data.SqlClient;

namespace Olimpia_Front_End.Models
{
    public class getIdCompany : System.Web.UI.Page
    {
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
    }
}