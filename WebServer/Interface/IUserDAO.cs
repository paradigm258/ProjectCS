using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Interface
{
    interface IUserDAO
    {
        bool CheckUser(string username, string password); // check dung' hay k
        bool CheckUsername(string username); //check co' username chua //true= co'
        User GetUser(string username);
        List<string> Top20ShareableUsers(string search);//filter theo search // like '%search%'
        bool AddUser(string username, string password);//isAdmin = false//quota = 0
        bool DeleteUser(string username);//delete het tat ca lien quan den user trong ca? 4 bang?
        List<User> GetAllUsers();//co' paging
        bool UpdateUsedQuota(string username, int newUsedQuota);
        bool UpdateMaxQuota(string username, int newMaxQuota);
    }
}
