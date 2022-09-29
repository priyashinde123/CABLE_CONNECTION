using CABLE_OPERATIONS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CABLE_OPERATIONS.Operations
{
    public class City_Operation
    {
        private string _connectionString;
        public City_Operation(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<City> GetCities(string input)
        {
            List<City> cities = new List<City>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand($"select c.[id],c.[city_name] from city as c where c.[city_name] like '{input}%'", connection);

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    City c = new City();
                    c.id = (int)reader[0];
                    c.name = (string)reader[1];

                    cities.Add(c);

                }

                connection.Close();

            }

            return cities;
        }
    }
}
