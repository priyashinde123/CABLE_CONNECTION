using CABLE_OPERATIONS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CABLE_OPERATIONS.Operations
{
    public  class Agent_Operation
    {
        private string _connectionString;
        public Agent_Operation(string connectionString)
        {
           _connectionString = connectionString;
        }
        public List<Agent> GetAgentList()
        {
            List<Agent> agents = new List<Agent>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand($"[dbo].[usp_GetAgent]", connection);

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Agent c = new Agent();
                    c.id = (int)reader[0];
                    c.name = (string)reader[1];
                    agents.Add(c);

                }

                connection.Close();

            }

            return agents;

        }

        public Agent GetAgent(string username)
        {

            Agent agent = new Agent();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand($"[dbo].[usp_GetAgent]{username}", connection);

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    agent.id = (int)reader[0];
                    agent.name = (string)reader[1];
                    agent.authority_id = (int)reader[2];
                    agent.gid = (int)reader[3];
                    agent.agent_username = (string)reader[4];
                    agent.agent_password = (string)reader[5];
                   

                }

                connection.Close();

            }

            return agent;

        }
    }
}
