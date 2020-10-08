using EPAM.FinalProject.DAL.Interface;
using EPAM.FinalProject.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EPAM.FinalProject.DAL
{
    public class UserSQLDao : IUserDAO
    {
        private string _connectionString;

        public UserSQLDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public void Add(User user)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddUser";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterName = new SqlParameter("@Name", user.Name);
                command.Parameters.Add(parameterName);

                SqlParameter parameterDateOfBirth = new SqlParameter("@DateOfBirth", user.DateOfBirth);
                command.Parameters.Add(parameterDateOfBirth);

                SqlParameter parameterLogin = new SqlParameter("@Login", user.Login);
                command.Parameters.Add(parameterLogin);

                SqlParameter parameterPassword = new SqlParameter("@Pass", user.Password);
                command.Parameters.Add(parameterPassword);

                SqlParameter parameterRole = new SqlParameter("@Role", user.Role);
                command.Parameters.Add(parameterRole);

                SqlParameter parameterIcon = new SqlParameter("@Icon", user.Icon);
                command.Parameters.Add(parameterIcon);

                sqlConnection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }

        public bool Delete(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "DeleteUser";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@Id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                var reader = command.ExecuteNonQuery();
                return true;
            }
        }

        public void Edit(User user)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "EditUser";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@Id", user.ID);
                command.Parameters.Add(parameterId);

                SqlParameter parameterName = new SqlParameter("@Name", user.Name);
                command.Parameters.Add(parameterName);

                SqlParameter parameterDateOfBirth = new SqlParameter("@DateOfBirth", user.DateOfBirth);
                command.Parameters.Add(parameterDateOfBirth);

                SqlParameter parameterLogin = new SqlParameter("@Login", user.Login);
                command.Parameters.Add(parameterLogin);

                SqlParameter parameterPassword = new SqlParameter("@Pass", user.Password);
                command.Parameters.Add(parameterPassword);

                SqlParameter parameterRole = new SqlParameter("@Role", user.Role);
                command.Parameters.Add(parameterRole);

                SqlParameter parameterIcon = new SqlParameter("@Icon", user.Icon);
                command.Parameters.Add(parameterIcon);

                sqlConnection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            var result = new List<User>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllUsers";
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new User
                        {
                            ID = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            DateOfBirth = (DateTime)reader["DateOfBirth"],
                            Login = (string)reader["Login"],
                            Password = (string)reader["Password"],
                            Role = (string)reader["Role"],
                            Icon = (string)reader["Icon"],
                        });
                }
            }

            return result;
        }

        public User GetById(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetUserById";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterId = new SqlParameter("@Id", id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                User result = new User();
                while (reader.Read())
                {
                    result =
                        new User
                        {
                            ID = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            DateOfBirth = (DateTime)reader["DateOfBirth"],
                            Login = (string)reader["Login"],
                            Password = (string)reader["Password"],
                            Role = (string)reader["Role"],
                            Icon = (string)reader["Icon"],
                        };
                }

                return result;
            }
        }
    }
}
