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
        public bool checkPermit(int fileId,string username)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = new SqlCommand("select count(*) from Permit where fileID=@fileID  and username = @user", connection);
                command.Parameters.AddWithValue("@fileID", fileId);
                command.Parameters.AddWithValue("@user", username);
                return (int)command.ExecuteScalar() == 1;
            }
        }

        public bool AddPermit(int fileId, string user)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("insert into Permit values(@id,@user)");
                command.Parameters.AddWithValue("@id", fileId);
                command.Parameters.AddWithValue(@"user", user);
                connection.Open();
                return command.ExecuteNonQuery() == 1 ? true : false;
            }
        }

        public bool DeleteAllPermit(int fileId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("delete from Permit where id=@id");
                command.Parameters.AddWithValue("@id", fileId);
                connection.Open();
                return command.ExecuteNonQuery() > 1;
            }
        }

        public bool DeleteUserPermit(int fileId,string user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("delete from Permit where id=@id and username=@user");
                command.Parameters.AddWithValue("@id", fileId);
                command.Parameters.AddWithValue(@"user", user);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public List<User> SharedUsers(int itemId)
        {
            throw new NotImplementedException();
        }

        public bool CheckPermit(int itemId, string username)
        {
            throw new NotImplementedException();
        }
    }
}