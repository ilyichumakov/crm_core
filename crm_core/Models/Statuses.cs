using System;
using System.Collections.Generic;

namespace crm_core
{
    public partial class Statuses : Models.AbstractModel
    {
        public Statuses()
        {
            Bills = new HashSet<Bills>();
            Deals = new HashSet<Deals>();
            Leads = new HashSet<Leads>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Entity { get; set; }

        public virtual ICollection<Bills> Bills { get; set; }
        public virtual ICollection<Deals> Deals { get; set; }
        public virtual ICollection<Leads> Leads { get; set; }
    }
}
