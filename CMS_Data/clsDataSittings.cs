using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CMS_Data
{
    public class clsDataSittings
    {
        //public static string connectionString = "Server=.;Database=CMS;User id=sa;Password=mohammed713784171;";
        public static string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
    }
    
}
