using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebServer.Interface;
using WebServer.Model;

namespace WebServer.Dao
{
    public class SyncFolderDAO : DAO, ISyncFolderDAO
    {
        public void AddSyncFolder(SyncFolder syncFolder)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"insert into SyncFolder values(@id,@item,@username)";
                SqlCommand command = new SqlCommand(query,connection);
                command.Parameters.AddWithValue("@id", syncFolder.ID);
                command.Parameters.AddWithValue("@item", syncFolder.ItemID);
                command.Parameters.AddWithValue("@username", syncFolder.Username);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteSyncFolder(int id)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"delete from SyncFolder where id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Model.SyncFolder> SyncFolders(string username)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"select * from SyncFolder where username = @username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<SyncFolder> list = new List<SyncFolder>();
                while (reader.HasRows)
                {
                    list.Add(new SyncFolder()
                    {
                        ID = (int)reader["id"],
                        ItemID = (int)reader["item"],
                        Username = (string)reader["username"]
                    });
                    reader.Read();
                }
                return list;
            }
        }

        Model.SyncFolder ISyncFolderDAO.SyncFolder(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                string query = @"select * from SyncFolder where id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return new SyncFolder()
                    {
                        ID = (int)reader[0],
                        ItemID = (int)reader[1],
                        Username = (string)reader[2]
                    };
                }
                return null;
            }         
        }
    }
}