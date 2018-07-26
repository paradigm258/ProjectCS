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
    public class PermitDAO:DAO,IPermitDAO
    {
        public bool checkPermit(int itemId,string username)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("select count(*) from Permit where itemId=@itemID  and username = @user", connection);
                command.Parameters.AddWithValue("@itemID", itemId);
                command.Parameters.AddWithValue("@user", username);
                return (int)command.ExecuteScalar() == 1;
            }
        }

        public bool AddPermit(int itemId, string user)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("insert into Permit values(@id,@user)",connection);
                command.Parameters.AddWithValue("@id", itemId);
                command.Parameters.AddWithValue(@"user", user);
                connection.Open();
                return command.ExecuteNonQuery() == 1 ? true : false;
            }
        }

        public bool DeleteAllPermit(int itemId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("delete from Permit where itemId=@id",connection);
                command.Parameters.AddWithValue("@id", itemId);
                connection.Open();
                return command.ExecuteNonQuery() > 1;
            }
        }

        public bool DeleteUserPermit(int itemId,string user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("delete from Permit where itemId=@id and username=@user",connection);
                command.Parameters.AddWithValue("@id", itemId);
                command.Parameters.AddWithValue(@"user", user);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public List<User> SharedUsers(int itemId)
        {
            string query = @"select * from Users where username in select username from Permit where itemID=@id";
            SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("id", itemId);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<User> users = new List<User>();
            foreach(DataRow r in dt.Rows){
                User u = new User()
                {
                    Username = (string)r[0],
                    Password = (string)r[1],
                    IsAdmin = (bool)r[2],
                    UsedQuota = (int)r[3],
                    MaxQuota = (int)r[4]
                };
                users.Add(u);
            }
            return users;
        }

        public bool CheckPermit(int itemId, string username)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"select count(*) from Permit where itemID=@id and username=@user";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", itemId);
                command.Parameters.AddWithValue("@user", username);
                return (int)command.ExecuteScalar() > 0;
            }
        }
    }
}