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
    public class RewardDBDAO:IRewardDAO
    {
        private readonly string _connectionString = "Data Source=USER-ПК\\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True;MultipleActiveResultSets=true";


        public IList<Reward> GetAllRewards()
        {
            var rewards = new List<Reward>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Title, Description FROM Rewards";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string description;

                    if (reader[2].ToString().Length != 0)
                    {
                         description = reader.GetString(2);
                    }
                    else {  description = string.Empty; }
                    
                    Reward reward = new Reward(id, title, description);
                    rewards.Add(reward);
                }
                return rewards;
            }

           
        }
        public void AddReward(Reward reward)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddReward";
                command.CommandType = CommandType.StoredProcedure;

                
                command.Parameters.Add("title", SqlDbType.NVarChar).Value = reward.Title;
                command.Parameters.Add("description", SqlDbType.NVarChar).Value = reward.Description;

                connection.Open();
                var reader = command.ExecuteNonQuery();

            }
        }
        public void DeleteReward(Reward reward)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "DeleteReward";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("rewardId", SqlDbType.Int).Value = reward.ID;

                connection.Open();
                var reader = command.ExecuteNonQuery();

            }
        }
        public void EditReward(Reward reward, string newTitle, string newDescriprion)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "EditReward";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("id", SqlDbType.Int).Value = reward.ID;
                command.Parameters.Add("title", SqlDbType.NVarChar).Value = newTitle;
                command.Parameters.Add("description", SqlDbType.NVarChar).Value = newDescriprion;

                connection.Open();
                var reader = command.ExecuteNonQuery();

            }
        }
    }
}
