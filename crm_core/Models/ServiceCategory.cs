using System;
using System.Collections.Generic;

namespace crm_core
{
    public partial class ServiceCategory : Models.AbstractModel
    {
        public ServiceCategory()
        {
            Services = new HashSet<Services>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }

        public virtual ICollection<Services> Services { get; set; }
    }
}
