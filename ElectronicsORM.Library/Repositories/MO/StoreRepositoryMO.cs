using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.DataAccess;
using ElectronicsORM.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ElectronicsORM.Library.Repositories.MO
{
    public class StoreRepositoryMO : IStoreRepository
    {
        readonly SqlConnection _dbConn;

        public StoreRepositoryMO()
        {
            _dbConn = new SqlConnection(MsSql.GetConnectionString());
        }

        public Store Getstore(int storeId)
        {
            throw new NotImplementedException();
        }

        public bool StoreExists(int storeId)
        {
            bool result = false;

            string query = "SELECT COUNT(1) FROM Store WHERE Id=@Id ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", storeId));

            if (_dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    _dbConn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                int count = (int)cmd.ExecuteScalar();

                if (count == 1)
                {
                    result = true;
                }
            }
            _dbConn.Close();

            return result;
        }
    }
}
