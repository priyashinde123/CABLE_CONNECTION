using CABLE_OPERATIONS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CABLE_OPERATIONS.Operations
{
    public class Customer_Dashboard_Operation
    {
        private string _connectionString;
        public Customer_Dashboard_Operation(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Customer_Dashboard GetCustomers_Dashboard(String username)
        {

            Customer_Dashboard cus_dash = new Customer_Dashboard();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand($"EXECUTE [dbo].[usp_Customer_Dashboard] {username}", connection);

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    cus_dash.name = (string)reader[0];
                    cus_dash.package_name = (string)reader[1];
                   
                }

                connection.Close();

            }

            return cus_dash;
        }
    }
}