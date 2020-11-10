using System;
using System.Collections.Generic;

namespace crm_core
{
    public partial class Users
    {
        public Users()
        {
            Staff = new HashSet<Staff>();
        }

        public string Username { get; set; }
        public int Id { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }
    }
}
