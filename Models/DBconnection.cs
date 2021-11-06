using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentsManagement.Models
{
    public class DBconnection
    {
        string strCon;
        public DBconnection()
        {
            strCon = ConfigurationManager.ConnectionStrings["DBconnect"].ConnectionString;
            
        }
        public SqlConnection getConnection()
        {
            return new SqlConnection(strCon);
        }
    }
}