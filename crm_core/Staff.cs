using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace crm_core
{
    public partial class Staff
    {
        public Staff()
        {
            Comments = new HashSet<Comments>();
            Posts = new HashSet<Posts>();
        }

        public string Username { get; set; }
        public int Id { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public int User { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public NpgsqlPath? Photo { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }

        public virtual Users UserNavigation { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
