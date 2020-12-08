using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace crm_core
{
    public partial class Users : Models.AbstractModel
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

        public bool validate_password(string password)
        {
            byte[] password_bytes = Encoding.ASCII.GetBytes(password);
            byte[] password_md_bytes = MD5.Create().ComputeHash(password_bytes);

            StringBuilder pass_md = new StringBuilder();
            foreach (byte b in password_md_bytes)
            {
                pass_md.Append(b.ToString("X2"));
            }

            byte[] salt_bytes = Encoding.ASCII.GetBytes(pass_md.ToString() + this.Salt);
            byte[] hashed_password_bytes = MD5.Create().ComputeHash(salt_bytes);

            StringBuilder hash_md = new StringBuilder();
            foreach (byte b in hashed_password_bytes)
            {
                hash_md.Append(b.ToString("X2"));
            }

            return hash_md.ToString().ToLower() == this.Password;
        }
    }
}
