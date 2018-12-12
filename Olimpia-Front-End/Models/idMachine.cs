using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Olimpia_Front_End.Models
{
    public class idMachine : System.Web.UI.Page
    {
        public string setIdMachine()
        {
            string idMachines = Session["getIdMachine"].ToString();
            return idMachines;
        }

        public string getIdMachines()
        {
            return setIdMachine();
        }
    }


}