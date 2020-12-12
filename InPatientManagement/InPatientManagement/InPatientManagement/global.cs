using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace InPatientManagement
{
    public class global
    {
        public static string category = "", msgBoxHead = "IPMS";
        public static string NMode = "NEW", MMode = "MODIFY", DMode = "DELETE", VMode = "VIEW", RMode = "RESET";
        DataTable dt_treatment = new DataTable();
        DataTable dt_ward = new DataTable();
        public static string retStr = "",retName="",retStatus="",OldPass="";
        public static int indx = 0;
        public static bool flag;
}
     
}
