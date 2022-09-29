using CABLE_OPERATIONS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CABLE_OPERATIONS.Operations
{
    public class Customer_Operation
    {
        private string _connectionString;
        public Customer_Operation(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Customer> GetCustomerslist()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand($"EXECUTE [dbo].[usp_GetCustomer]", connection);

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Customer c = new Customer();
                    c.id = (int)reader[0];
                    c.first_name = (string)reader[1];
                    c.last_name = (string)reader[2];
                    c.contact = (string)reader[3];
                    c.address = (string)reader[4];
                    c.package_id= (int)reader[5];
                    c.status_id= (int)reader[6];
                    c.connection_date = (DateTime)reader[7];
                    c.gid = (int)reader[8]; 
                    c.city_id   = (int)reader[9];
                    c.user_name = (string)reader[10];   
                    c.password  = (string)reader[11];
                   

                    customers.Add(c);

                }

                connection.Close();

            }

            return customers;
        }


        public bool IsValidateLogin(String username, String password)
        {
            List<Customer> customer = GetCustomerslist();

            foreach (Customer c in customer)
            {
                if (c.user_name.Equals(username) && c.password.Equals(password))
                    return true;
            }
            return false;
            
        }

        public  Customer GetCustomer(String username)
        {  
            List<Customer> customer = GetCustomerslist();

            foreach (Customer c in customer)
            {
                if (c.user_name.Equals(username))
                    return c;
            }
            return null;
        }

        

        public static implicit operator Customer_Operation(Customer_Dashboard_Operation v)
        {
            throw new NotImplementedException();
        }
    }
}
