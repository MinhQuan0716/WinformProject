using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.DataAcess
{
    public class RoleDAO
    {
        //using singleton pattern 
        private static RoleDAO instance = null;
        private static readonly object instanceLock = new object();
        private RoleDAO() { }
        //-----------------------------------//
        public static RoleDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoleDAO();
                    }
                    return instance;
                }
            }
        }
        public List<AccountRole> GetAccountRoles()
        {
            var Role = new List<AccountRole>();
            try
            {
                var context = new StudentManagementContext();
                Role = context.AccountRoles.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Role;
        }
    }
}

