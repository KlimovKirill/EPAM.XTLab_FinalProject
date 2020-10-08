using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EPAM.FinalProject.DAL.Interface;
using EPAM.FinalProject.Entities;

namespace EPAM.FinalProject.DAL
{
    public class MessageSQLDao : IMessageDAO
    {
        private string _connectionString;

        public MessageSQLDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public void Add(Message message)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddMessage";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterText = new SqlParameter("@Text", message.Text);
                command.Parameters.Add(parameterText);

                SqlParameter parameterAuthor = new SqlParameter("@Author", message.Author);
                command.Parameters.Add(parameterAuthor);

                SqlParameter parameterCreationDate = new SqlParameter("@CreationDate", message.CreationDate);
                command.Parameters.Add(parameterCreationDate);

                SqlParameter parameterTopicID = new SqlParameter("@TopicID", message.TopicID);
                command.Parameters.Add(parameterTopicID);

                sqlConnection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }

        public bool Delete(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "DeleteMessage";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@Id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                var reader = command.ExecuteNonQuery();
                return true;
            }
        }

        public void Edit(Message message)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "EditMessage";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@Id", message.ID);
                command.Parameters.Add(parameterId);

                SqlParameter parameterText = new SqlParameter("@Text", message.Text);
                command.Parameters.Add(parameterText);

                sqlConnection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Message> GetAllMessagesInTopic(int topicID)
        {
            var result = new List<Message>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllMessagesInTopic";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterTopicID = new SqlParameter("@TopicID", topicID);
                command.Parameters.Add(parameterTopicID);

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Message
                        {
                            ID = (int)reader["Id"],
                            CreationDate = (DateTime)reader["CreationDate"],
                            Text = (string)reader["Text"],
                            Author = (string)reader["AuthorName"],
                            TopicID = (int)reader["TopicId"],
                        });
                }
            }

            return result;
        }

        public Message GetMessageById(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetMessageById";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@Id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                Message result = new Message();
                while (reader.Read())
                {
                    result =
                        new Message
                        {
                            ID = (int)reader["Id"],
                            Text = (string)reader["Text"],
                            Author = (string)reader["AuthorName"],
                            CreationDate = (DateTime)reader["CreationDate"],
                            TopicID = (int)reader["TopicId"],
                        };
                }

                return result;
            }
        }
    }
    
}
