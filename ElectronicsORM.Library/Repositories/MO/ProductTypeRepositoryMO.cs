using ElectronicsModel.Library.Models;
using ElectronicsORM.Library.DataAccess;
using ElectronicsORM.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ElectronicsORM.Library.Repositories.MO
{
    public class ProductTypeRepositoryMO : IProductTypeRepository
    {
        readonly SqlConnection _dbConn;

        public ProductTypeRepositoryMO()
        {
            _dbConn = new SqlConnection(MsSql.GetConnectionString());
        }

        public ProductType GetProductType(int productTypeId)
        {
            throw new NotImplementedException();
        }

        public bool ProductTypeExists(int productTypeId)
        {
            bool result = false;

            string query = "SELECT COUNT(1) FROM ProductType WHERE Id=@Id ";
            SqlCommand cmd = new SqlCommand(query, _dbConn);
            cmd.Parameters.Add(new SqlParameter("@Id", productTypeId));

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
