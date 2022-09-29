using CABLE_OPERATIONS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CABLE_OPERATIONS.Operations
{
    public class Usp_Yearly_Statement_Operation
    {
        private string _connectionString;
        public Usp_Yearly_Statement_Operation(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Usp_Yearly_Statement> GetYearlyStatement(string input,int year)
        {
            List<Usp_Yearly_Statement> statements = new List<Usp_Yearly_Statement>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand($"EXECUTE [dbo].[usp_yearly_statement]{input},{year}", connection);

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Usp_Yearly_Statement c = new Usp_Yearly_Statement();
                    c.monthid=(int)reader[0];
                    c.month = (string)reader[1];
                     c.year  = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2);
                   // c.year = reader[2] != null ? reader[2].ToString() : "";
                    c.month_= reader[3] != null ? reader[3].ToString() : "";
                   //  c.payment_date = (DateTime)reader[4];
                    c.payment_date = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4);
                    c.paid_amount = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5);

                    statements.Add(c);

                }

                connection.Close();

            }

            return statements;
        }
    }
}
