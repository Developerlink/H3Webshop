using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.DataAccess;
using ElectronicsORM.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ElectronicsORM.Library.Repositories.MO
{
    public class PostalCodeRepositoryMO : IPostalCodeRepository
    {
        readonly SqlConnection _dbConn;

        public PostalCodeRepositoryMO()
        {
            _dbConn = new SqlConnection(MsSql.GetConnectionString());
        }

        public PostalCode GetPostalCode(int postalCodeId)
        {
            throw new NotImplementedException();
        }

        public bool PostalCodeExists(int postalCodeId)
        {
            bool result = false;
            string query = "SELECT COUNT(1) FROM PostalCode WHERE PostalCodeId=@Id ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", postalCodeId));

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
