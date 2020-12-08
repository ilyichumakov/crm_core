using System;
using System.Collections.Generic;

namespace crm_core
{
    public partial class Leads : Models.AbstractModel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public int Status { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }

        public virtual Statuses StatusNavigation { get; set; }
    }
}
