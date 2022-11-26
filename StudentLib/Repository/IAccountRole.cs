using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.Repository
{
  public  interface IAccountRole
    {
        List<AccountRole> GetAccountRoles();
    }
}
