using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ElectronicsORM.Library.DataAccess
{
    public static class MsSql
    {
        public static SqlConnection GetSqlConnection()
        {
            if (Environment.MachineName == "WLT02")
            {
                return new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectronicsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            } 
            else
            {
                return new SqlConnection("Data Source=DESKTOP-AM7NCT3;Initial Catalog=ElectronicsDB;Integrated Security=True");
                // In case you can't connect to the db the problem might be the extra space in the string like so:
                // return new SqlConnection("Data Source = DESKTOP - AM7NCT3; Initial Catalog = ElectronicsDB; Integrated Security = True");
            }
            
        }
    }
}
