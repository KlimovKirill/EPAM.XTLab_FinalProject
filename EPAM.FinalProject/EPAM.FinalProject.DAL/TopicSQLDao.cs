using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EPAM.FinalProject.DAL.Interface;
using EPAM.FinalProject.Entities;

namespace EPAM.FinalProject.DAL
{
    public class TopicSQLDao : ITopicDAO
    {
        private string _connectionString;

        public TopicSQLDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public void Add(Topic topic)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddTopic";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterName = new SqlParameter("@Name", topic.Name);
                command.Parameters.Add(parameterName);

                SqlParameter parameterCreationDate = new SqlParameter("@CreationDate", topic.CreationDate);
                command.Parameters.Add(parameterCreationDate);

                sqlConnection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }

        public bool Delete(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "DeleteTopic";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@Id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                var reader = command.ExecuteNonQuery();
                return true;
            }
        }

        public void Edit(Topic topic)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "EditTopic";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@Id", topic.ID);
                command.Parameters.Add(parameterId);

                SqlParameter parameterName = new SqlParameter("@Name", topic.Name);
                command.Parameters.Add(parameterName);

                sqlConnection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }

        public Topic GetTopicById(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetTopicById";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@Id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                Topic result = new Topic();
                while (reader.Read())
                {
                    result =
                        new Topic
                        {
                            ID = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            CreationDate = (DateTime)reader["CreationDate"],
                        };
                }

                return result;
            }
        }

        public IEnumerable<Topic> ShowAllTopics()
        {
            var result = new List<Topic>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllTopics";
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Topic
                        {
                            ID = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            CreationDate = (DateTime)reader["CreationDate"],
                        });
                }
            }

            return result;
        }
    }
}
