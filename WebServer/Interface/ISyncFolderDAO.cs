using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Interface
{
    interface ISyncFolderDAO
    {
        SyncFolder SyncFolder(int id);
        List<SyncFolder> SyncFolders(string username);
        void AddSyncFolder(SyncFolder syncFolder);
        void DeleteSyncFolder(int id);
    }
}
