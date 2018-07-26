using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Interface
{
    interface IPermiDAO
    {
        List<Model.User> SharedUsers(int itemId);
        bool CheckPermit(int itemId, string username);
        bool AddPermit(int itemId, string usenamer);
        bool DeleteAllPermit(int itemId);
        bool DeleteUserPermit(int itemId, string username);
    }
}
