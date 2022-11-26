using StudentLib.DataAcess;
using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public void AddNew(Account account)
        {
            AccountDAO.Instance.AddNew(account);
        }

        public int CheckLogin(string username, string password)=>AccountDAO.Instance.GetAccountRole(username, password);

        public Account GetAccount(int id) => AccountDAO.Instance.GetAccountByID(id);
       
        public IEnumerable<Account> GetAll()=>AccountDAO.Instance.GetAccountsList();

        public Account GetLoginInfo(string username, string password, int roleid)=>AccountDAO.Instance.GetLoginInfo(username, password, roleid);
       

        public List<Account> GetStudent() => AccountDAO.Instance.GetStudentName();
       

        public List<Account> GetTeacher() => AccountDAO.Instance.GetTeacherName();
       

        public void Remove(int id)
        {
            AccountDAO.Instance.Remove(id);
        }

        public void Update(Account account)
        {
            AccountDAO.Instance.Update(account);
        }
    }
}
