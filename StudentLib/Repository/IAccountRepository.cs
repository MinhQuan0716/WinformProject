using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.Repository
{
    public  interface IAccountRepository
    {
        IEnumerable<Account> GetAll();
        Account GetAccount(int id);
        Account GetLoginInfo(string username, string password,int roleid);
        int CheckLogin(string username, string password);
        void AddNew(Account account);
        void Update(Account account);
        void Remove(int id);
        List<Account> GetTeacher();
        List<Account> GetStudent();
    }
}
