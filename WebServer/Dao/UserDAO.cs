using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.Model;
using System.Data;
using System.Data.SqlClient;
using WebServer.Interface;

namespace WebServer.Dao
{
    public class UserDAO : DAO, IUserDAO
    {
        public bool CheckUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"select count(*) from Users where username=@username and password=@password";
                SqlCommand command = new SqlCommand(query,connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                return (int)command.ExecuteScalar() == 1;
            }
        }

        public bool CheckAdmin(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"select count(*) from Users where username=@username and password=@password and isAdmin = @isAdmin";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@isAdmin", true);
                connection.Open();
                return (int)command.ExecuteScalar() == 1;
            }
        }
        public bool CheckUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"select count(*) from Users where username=@username";
                SqlCommand command = new SqlCommand(query,connection);
                command.Parameters.AddWithValue("@username", username);
                connection.Open();
                return (int)command.ExecuteScalar() == 1;
            }
        }
        public User GetUser(string username)
        {
            string query = @"select * from Users where username = @user";
            SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("@user", username);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new User()
                {
                    Username = (string)dr["username"],
                    Password = (string)dr["password"],
                    IsAdmin = (bool)dr["isAdmin"],
                    UsedQuota = (long)dr["usedQuota"],
                    MaxQuota = (long)dr["maxQuota"]
                };
            }
            return null;
        }
        public List<String> ShareAble(int fileId, string keyword)
        {
            string query = @"select username from Users where username in (select username from Users except select username from Permit where fileID=@id) and username like @keyword";
            SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("@id", fileId);
            da.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<string> list = new List<string>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add((string)r["username"]);
            }
            return list;
        }
        public bool AddUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("insert into Users values(@username,@password,0,0,2147483648)", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }


        public bool DeleteUser(string username)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("delete from Users where username=@username", connection);
                command.Parameters.AddWithValue("@username", username);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }
        public List<User> GetAllUsers()
        {
            string query = @"select * from Users";
            SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<User> List = new List<User>();
            foreach (DataRow r in dt.Rows)
            {
                List.Add(new User()
                {
                    Username = (string)r[0],
                    Password = (string)r[1],
                    IsAdmin = (bool)r[2],
                    UsedQuota = (long)r[3],
                    MaxQuota = (long)r[4]
                });
            }
            return List;
        }
        public bool UpdateQuota(string username, long quota)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("update Users set quota=@quota where username=@username",connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@quota", quota);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public List<string> Top20ShareableUsers(int id, string search)
        {
            string query = @"select username from Users where username in (select username from Users except select username from Permits where itemID=@id) and username like @keyword";
            SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            da.SelectCommand.Parameters.AddWithValue("@keyword", "%" + search + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<string> list = new List<string>();
            int limit = dt.Rows.Count >= 20 ? 20 : dt.Rows.Count;
            for (int i = 0; i < limit; i++)
            {
                DataRow row = dt.Rows[i];
                list.Add((string)row["username"]);
            }
            return list;
        }

        public bool UpdateUsedQuota(string username, long newUsedQuota)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"update Users set usedQuota=@quota where username=@user";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@quota", newUsedQuota);
                command.Parameters.AddWithValue("@user", username);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool UpdateMaxQuota(string username, long newMaxQuota)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"update Users set maxQuota=@quota where username=@user";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@quota", newMaxQuota);
                command.Parameters.AddWithValue("@user", username);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

    }
}