using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CABLE_OPERATIONS.Operations
{
    public class Customer_Query_Operation
    {
        private string _connectionString;
        public Customer_Query_Operation(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool RaiseQuery(int id, string qery)
        {


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand($"EXECUTE [dbo].[Raise_Query]{id},'{qery}'", connection);

               connection.Open();


               SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {

                }

               connection.Close();

            }
            return true;
        }
    }
}
