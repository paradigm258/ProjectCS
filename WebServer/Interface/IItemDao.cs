using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Interface
{
    interface IItemDao
    {
        List<Item> GetAllItemsWithNullParent(string owner);
        List<Item> GetAllItemsWithParent(string owner, int parent);
        Item GetItem(string owner, string name);//get all info of item
        Item GetItem(int id);
        List<Item> GetAllSharedItems(string username);//get all items shared to this user
        bool CheckItem(string owner, string itemName);//check if user has already uploaded this item or not
        bool UpdateItem(int id, string name, bool isPublic, long size, int parent);//update according to id
        bool AddItem(string name, string owner, bool isPublic, bool isFolder, long size, int parent);
        bool DeleteItem(int id);
    }
}
