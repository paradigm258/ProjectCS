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
    public class UserDAO:DAO, IUserDAO
    {
        //public bool CheckUserLogin(string username, string password)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString)) {
        //        string query = @"select count(*) from User where username=@username and password=@password";
        //        SqlCommand command = new SqlCommand(query);
        //        command.Parameters.AddWithValue("@username", username);
        //        command.Parameters.AddWithValue("@password", password);
        //        connection.Open();
        //        return (int)command.ExecuteScalar() == 1;
        //    }
        //}
        //public bool CheckUserExist(string username)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        string query = @"select count(*) from User where username=@username";
        //        SqlCommand command = new SqlCommand(query);
        //        command.Parameters.AddWithValue("@username", username);
        //        connection.Open();
        //        return (int)command.ExecuteScalar() == 1;
        //    }
        //}
        //public User User(string username)
        //{
        //    string query = @"select * from User where username = @user";
        //    SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
        //    da.SelectCommand.Parameters.AddWithValue("@user", username);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //    {
        //        DataRow dr = dt.Rows[0];
        //        return new User()
        //        { 
        //            username = (string)dr["username"],
        //            password = (string)dr["password"]
        //        };
        //    }
        //    return null;
        //}
        //public List<String> ShareAble(int fileId, string keyword)
        //{
        //    string query = @"select username from User where username in (select username from User except select username from Permit where fileID=@id) and username like @keyword";
        //    SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
        //    da.SelectCommand.Parameters.AddWithValue("@id", fileId);
        //    da.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    List<string> list = new List<string>();
        //    foreach(DataRow r in dt.Rows){
        //        list.Add((string)r["username"]);
        //    }
        //    return list;
        //}
        //public bool AddUser(User user)
        //{
        //    using(SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand("insert into User values(@username,@password,@quota)");
        //        command.Parameters.AddWithValue("@username", user.username);
        //        command.Parameters.AddWithValue("@password", user.password);
        //        command.Parameters.AddWithValue("@quota", user.quota);
        //        connection.Open();
        //        return command.ExecuteNonQuery() == 1;
        //    }
        //}

        //public bool UpdateUser(User user)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand("update User set password = @password, quota=@quota where username=@username");
        //        command.Parameters.AddWithValue("@username", user.username);
        //        command.Parameters.AddWithValue("@password", user.password);
        //        command.Parameters.AddWithValue("@quota", user.quota);
        //        connection.Open();
        //        return command.ExecuteNonQuery() == 1;
        //    }
        //}

        //public bool DeleteUser(string username)
        //{
        //    using(SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand("delete from User where username=@username", connection);
        //        command.Parameters.AddWithValue("@username", username);
        //        connection.Open();
        //        return command.ExecuteNonQuery() == 1;
        //    }
        //}
        //public DataTable Users()
        //{
        //    string query = @"select * from User";
        //    SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    return dt;
        //}
        //public bool UpdateQuota(string username,long quota)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand("update User set quota=@quota where username=@username");
        //        command.Parameters.AddWithValue("@username", username);
        //        command.Parameters.AddWithValue("@quota", quota);
        //        connection.Open();
        //        return command.ExecuteNonQuery() == 1;
        //    }
        //}

        public bool CheckUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool CheckUsername(string username)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public List<string> Top20ShareableUsers(string search)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public bool UpdateUsedQuota(string username, int newUsedQuota)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMaxQuota(string username, int newMaxQuota)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}