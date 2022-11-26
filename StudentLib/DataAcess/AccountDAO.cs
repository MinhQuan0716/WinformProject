using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentLib.Models;
using System.Runtime.ConstrainedExecution;

namespace StudentLib.DataAcess
{
    public  class AccountDAO
    {


        //using singleton pattern 
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        private AccountDAO() { }
        //-----------------------------------//
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Account> GetAccountsList()
        {
            var Account =new List<Account>();
            try
            {
                using var context = new StudentManagementContext();
                Account=context.Accounts.ToList();
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Account;
        }
        public int GetAccountRole(string username,string password)
        {
            int role=0;
            var context = new StudentManagementContext();
            var account = context.Accounts.Where(a => a.Username == username && a.PassWord == password);
            List<Account> acc = account.ToList();
            foreach(Account  item in account)
            {
                 role = (int)item.Roleid; 
            }
            return role;
        }
        public Account GetAccountByID(int carlD)
        {
            Account account = null;
            try
            {
                using var context = new StudentManagementContext();
                account = context.Accounts.SingleOrDefault(c => c.AccountId == carlD);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }
        public Account GetLoginInfo(string username, string password, int role)
        {
            Account account = null;
            try
            {
                using var context = new StudentManagementContext();
                account = context.Accounts.SingleOrDefault(c => c.Username.Equals(username) && c.PassWord.Equals(password) && c.Roleid == role);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }
        public List<Account> GetTeacherName()
        {
            List<Account> accountList = new List<Account>();
            try
            {
                using var context = new StudentManagementContext();
                accountList = context.Accounts.Where(a => a.Roleid == 2).ToList();

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accountList;
        }
        public List<Account> GetStudentName()
        {
            List<Account> accountList = new List<Account>();
            try
            {
                using var context = new StudentManagementContext();
                accountList = context.Accounts.Where(a => a.Roleid == 3).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accountList;
        }
        public void AddNew(Account account)
        {
            try
            {
                Account _account = GetAccountByID(account.AccountId);
                if (_account == null)
                {
                    using var context = new StudentManagementContext();
                    context.Accounts.Add(account);
                    context.SaveChanges();
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Account account)
        {
            try
            {
                Account _account = GetAccountByID(account.AccountId);
                if (_account != null)
                {
                    using var context = new StudentManagementContext();
                    context.Accounts.Update(account);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(int id)
        {
            try
            {
                Account account = GetAccountByID(id);
                if (account != null)
                {
                    using var context = new StudentManagementContext();
                    context.Accounts.Remove(account);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
