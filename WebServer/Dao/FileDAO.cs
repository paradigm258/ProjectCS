using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.Model;
using System.Data;
using System.Data.SqlClient;

namespace WebServer.Dao
{
   
    public class FileDAO:DAO
    {
        
        public List<Item> Files(string owner)
        {
            string query = @"select * from File where owner = @owner";
            SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("@owner", owner);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Item> list = new List<Item>();
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(new Item()
                {
                    id = (int)dr["id"],
                    name = (string)dr["name"],
                    owner = (string)dr["owner"],
                    privacy = (string)dr["privacy"],
                    size = (long)dr["size"]
                });
            }
            return list;
        }
        public List<Item> SharedFiles(string user)
        {
            string query = @"select * from File where id in (select id from Permit where username = @user)";
            SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("@user", user);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Item> list = new List<Item>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Item()
                {
                    id = (int)dr["id"],
                    name = (string)dr["name"],
                    owner = (string)dr["owner"],
                    privacy = (string)dr["privacy"],
                    size = (long)dr["size"]
                });
            }
            return list;
        }

        public Item File(int id)
        {
            string query = @"select * from File where id = @id";
            SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new Item()
                {
                    id = (int)dr["id"],
                    name = (string)dr["name"],
                    owner = (string)dr["owner"],
                    privacy = (string)dr["privacy"],
                    size = (long)dr["size"]
                };
            }
            return null;
        }

        public bool UpdateFile(Item file)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command =
                    new SqlCommand("update File set name=@name,owner=@owner,privacy=@privacy,size=@size" +
                    " where id=@id");
                command.Parameters.AddWithValue("@id", file.id);
                command.Parameters.AddWithValue("@name", file.name);
                command.Parameters.AddWithValue("@owner", file.owner);
                command.Parameters.AddWithValue("@privacy", file.privacy);
                command.Parameters.AddWithValue("@size", file.size);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }
        public bool AddFile(Item file)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command =
                    new SqlCommand("insert into File values(@name,@owner,@privacy,@size)");
                command.Parameters.AddWithValue("@name", file.name);
                command.Parameters.AddWithValue("@owner", file.owner);
                command.Parameters.AddWithValue("@privacy", file.privacy);
                command.Parameters.AddWithValue("@size", file.size);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }
        public bool DeleteFile(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command =
                    new SqlCommand("delete from File where id=@id");
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }
        public bool UpdatePrivacy(int id,string privacy)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                Item file = this.File(id);
                
                SqlCommand command =
                    new SqlCommand("update File set privacy=@privacy where id=@id");
                command.Parameters.AddWithValue("@privacy", file.privacy == "public" ? "private" : "public");
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }
    }
}