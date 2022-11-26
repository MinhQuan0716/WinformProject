using StudentLib.DataAcess;
using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.Repository
{
    public class RoleRepository : IAccountRole
    {
        public List<AccountRole> GetAccountRoles()=>RoleDAO.Instance.GetAccountRoles();
      
    }
}
