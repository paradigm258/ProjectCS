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

    public class ItemDAO : DAO, IItemDao
    {

        //public List<Item> Files(string owner)
        //{
        //    string query = @"select * from File where owner = @owner";
        //    SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
        //    da.SelectCommand.Parameters.AddWithValue("@owner", owner);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    List<Item> list = new List<Item>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        list.Add(new Item()
        //        {
        //            id = (int)dr["id"],
        //            name = (string)dr["name"],
        //            owner = (string)dr["owner"],
        //            privacy = (string)dr["privacy"],
        //            size = (long)dr["size"]
        //        });
        //    }
        //    return list;
        //}
        //public List<Item> SharedFiles(string user)
        //{
        //    string query = @"select * from File where id in (select id from Permit where username = @user)";
        //    SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
        //    da.SelectCommand.Parameters.AddWithValue("@user", user);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    List<Item> list = new List<Item>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        list.Add(new Item()
        //        {
        //            id = (int)dr["id"],
        //            name = (string)dr["name"],
        //            owner = (string)dr["owner"],
        //            privacy = (string)dr["privacy"],
        //            size = (long)dr["size"]
        //        });
        //    }
        //    return list;
        //}

        //public Item File(int id)
        //{
        //    string query = @"select * from File where id = @id";
        //    SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
        //    da.SelectCommand.Parameters.AddWithValue("@id", id);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //    {
        //        DataRow dr = dt.Rows[0];
        //        return new Item()
        //        {
        //            id = (int)dr["id"],
        //            name = (string)dr["name"],
        //            owner = (string)dr["owner"],
        //            privacy = (string)dr["privacy"],
        //            size = (long)dr["size"]
        //        };
        //    }
        //    return null;
        //}

        //public bool UpdateFile(Item file)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand command =
        //            new SqlCommand("update File set name=@name,owner=@owner,privacy=@privacy,size=@size" +
        //            " where id=@id");
        //        command.Parameters.AddWithValue("@id", file.id);
        //        command.Parameters.AddWithValue("@name", file.name);
        //        command.Parameters.AddWithValue("@owner", file.owner);
        //        command.Parameters.AddWithValue("@privacy", file.privacy);
        //        command.Parameters.AddWithValue("@size", file.size);
        //        connection.Open();
        //        return command.ExecuteNonQuery() == 1;
        //    }
        //}
        //public bool AddFile(Item file)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand command =
        //            new SqlCommand("insert into File values(@name,@owner,@privacy,@size)");
        //        command.Parameters.AddWithValue("@name", file.name);
        //        command.Parameters.AddWithValue("@owner", file.owner);
        //        command.Parameters.AddWithValue("@privacy", file.privacy);
        //        command.Parameters.AddWithValue("@size", file.size);
        //        connection.Open();
        //        return command.ExecuteNonQuery() == 1;
        //    }
        //}
        //public bool DeleteFile(int id)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand command =
        //            new SqlCommand("delete from File where id=@id");
        //        command.Parameters.AddWithValue("@id", id);
        //        connection.Open();
        //        return command.ExecuteNonQuery() == 1;
        //    }
        //}
        //public bool UpdatePrivacy(int id, string privacy)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        Item file = this.File(id);

        //        SqlCommand command =
        //            new SqlCommand("update File set privacy=@privacy where id=@id");
        //        command.Parameters.AddWithValue("@privacy", file.privacy == "public" ? "private" : "public");
        //        connection.Open();
        //        return command.ExecuteNonQuery() == 1;
        //    }
        //}

        public List<Item> GetAllItemsWithNullParent(string owner)
        {
            string query = "select * from Items where owner='" + owner + "' and parent = 0";
            SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Item> itemList = new List<Item>();
            foreach (DataRow dr in dt.Rows)
            {
                Item i = new Item()
                {
                    id = (int)dr["id"],
                    name = (string)dr["name"],
                    owner = (string)dr["owner"],
                    isPublic = (bool)dr["isPublic"],
                    isFolder = (bool)dr["isFolder"],
                    size = (long)dr["size"],
                    parent = (int)dr["parent"]
                };
                itemList.Add(i);
            }
            return itemList;
        }

        public List<Item> GetAllItemsWithParent(string owner, int parent)
        {
            string query = "select * from Items where owner='" + owner + "' and parent ='" + parent + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Item> itemList = new List<Item>();
            foreach (DataRow dr in dt.Rows)
            {
                Item i = new Item()
                {
                    id = (int)dr["id"],
                    name = (string)dr["name"],
                    owner = (string)dr["owner"],
                    isPublic = (bool)dr["isPublic"],
                    isFolder = (bool)dr["isFolder"],
                    size = (long)dr["size"],
                    parent = (int)dr["parent"]
                };
                itemList.Add(i);
            }
            return itemList;
        }

        public Item GetItem(string owner, string name)
        {
            string query = @"select * from Items where owner = '" + owner + "' and name = '" + name + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            Item i = new Item()
            {
                id = (int)dr["id"],
                name = (string)dr["name"],
                owner = (string)dr["owner"],
                isPublic = (bool)dr["isPublic"],
                isFolder = (bool)dr["isFolder"],
                size = (long)dr["size"],
                parent = (int)dr["parent"]
            };
            return i;
        }


        public Item GetItem(int id)
        {
            string query = @"select * from Items where id = '" + id + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            Item i = new Item()
            {
                id = (int)dr["id"],
                name = (string)dr["name"],
                owner = (string)dr["owner"],
                isPublic = (bool)dr["isPublic"],
                isFolder = (bool)dr["isFolder"],
                size = (long)dr["size"],
                parent = (int)dr["parent"]
            };
            return i;
        }

        public List<Item> GetAllSharedItems(string username)
        {
            string query = "select * from Items i, Permits p where i.id=p.itemID";
            SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Item> itemList = new List<Item>();
            foreach (DataRow dr in dt.Rows)
            {
                Item i = new Item()
                {
                    id = (int)dr["id"],
                    name = (string)dr["name"],
                    owner = (string)dr["owner"],
                    isPublic = (bool)dr["isPublic"],
                    isFolder = (bool)dr["isFolder"],
                    size = (long)dr["size"],
                    parent = (int)dr["parent"]
                };
                itemList.Add(i);
            }
            return itemList;
        }

        public bool CheckItem(string owner, string itemName)
        {
            string query = "select * from Items i where i.owner='" + owner + "' and i.name='" + itemName + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateItem(int id, string name, bool isPublic, long size, int parent)
        {
            try
            {
                string query = @"update Items set name=@name, isPublic=@isPublic, size=@size, parent=@parent where id = @id";
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@isPublic", isPublic);
                cmd.Parameters.AddWithValue("@size", size);
                cmd.Parameters.AddWithValue("@parent", parent);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool AddItem(string name, string owner, bool isPublic, bool isFolder, long size, int parent)
        {

            string query = "insert into Items values (@name,@owner,@isPublic,@isFolder,@size,@parent)";
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@owner", owner);
            cmd.Parameters.AddWithValue("@isPublic", isPublic);
            cmd.Parameters.AddWithValue("@isFolder", isFolder);
            cmd.Parameters.AddWithValue("@size", size);
            cmd.Parameters.AddWithValue("@parent", parent);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }


        public bool DeleteItem(int id)
        {
            try
            {
                string query = "delete from Items where id='@id'";
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}