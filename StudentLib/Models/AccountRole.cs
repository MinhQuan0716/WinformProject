using System;
using System.Collections.Generic;

#nullable disable

namespace StudentLib.Models
{
    public partial class AccountRole
    {
        public AccountRole()
        {
            Accounts = new HashSet<Account>();
        }

        public int Roleid { get; set; }
        public string Rolename { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
