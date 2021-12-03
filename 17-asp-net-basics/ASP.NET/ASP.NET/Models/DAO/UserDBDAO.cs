using System;
using System.Data;
using System.Data.SqlClient;
using Entities;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using System.Configuration;

namespace DAL.DB
{
    public class UserDBDAO:IUserDAO
    {
        private readonly string _connectionString = "Data Source=USER-ПК\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True;MultipleActiveResultSets=true";
        private RewardDBDAO _rewardDBDAO = new RewardDBDAO();

        public IList<User> GetAllUsers()
        {
            var rewards = _rewardDBDAO.GetAllRewards();
            var users = new List<User>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, LastName, BirthDay FROM Users";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User(reader.GetInt32("Id"), reader.GetDateTime("Birthday"), reader.GetString("Name"), reader.GetString("LastName"));
                    
                    var com = connection.CreateCommand();          //////получаем награды пользователя
                    com.CommandText = "GetRewardsOfUser";
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("userId", SqlDbType.Int).Value = user.ID;

                    var reader1 = com.ExecuteReader();

                    while (reader1.Read())
                    {
                        foreach(Reward r in rewards)
                        {
                            if (reader1.GetInt32("RewardId") == r.ID) { user.Rewards.Add(r); }
                        }
                    }
                    users.Add(user);

                }

            }
            return users;
        }
        public void AddUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddUser";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("name", SqlDbType.NVarChar).Value = user.Name;
                command.Parameters.Add("lastName", SqlDbType.NVarChar).Value = user.LastName;
                command.Parameters.Add("birthday", SqlDbType.Date).Value = user.BirthDate;
                connection.Open();
                int id = (int)command.ExecuteScalar();


                foreach(Reward r in user.Rewards)
                {
                    var com = connection.CreateCommand();
                    com.CommandText = "AddRewardToUser";
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.Add("userId", SqlDbType.Int).Value = id;
                    com.Parameters.Add("rewardId", SqlDbType.Int).Value = r.ID;
                    com.ExecuteNonQuery();
                }
            }
        }
        public void DeleteUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "DeleteUser";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("userId", SqlDbType.Int).Value = user.ID;

                connection.Open();
                var reader = command.ExecuteNonQuery();

            }
        }
        public void EditUser(User user, string newName, string newLastName, DateTime newBirthDay)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "EditUser";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("id", SqlDbType.Int).Value = user.ID;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = newName;
                command.Parameters.Add("lastName", SqlDbType.NVarChar).Value = newLastName;
                command.Parameters.Add("birthday", SqlDbType.Date).Value = newBirthDay;

                connection.Open();
                var reader = command.ExecuteNonQuery();

            }
        }
        public void AddRewardToUser(User user, Reward reward)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddRewardToUser";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("userId", SqlDbType.Int).Value = user.ID;
                command.Parameters.Add("rewardId", SqlDbType.Int).Value = reward.ID;

                connection.Open();
                var reader = command.ExecuteNonQuery();

            }
        }
        public void DeleteRewardsOfUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "DeleteRewardsOfUser";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("userId", SqlDbType.Int).Value = user.ID;

                connection.Open();
                var reader = command.ExecuteNonQuery();

            }
        }
    }
}
