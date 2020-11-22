using System;
using System.Collections.Generic;

namespace crm_core
{
    public partial class Services
    {
        public Services()
        {
            GoodsToOrders = new HashSet<GoodsToOrders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int? Category { get; set; }
        public bool? Active { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }

        public virtual ServiceCategory CategoryNavigation { get; set; }
        public virtual ICollection<GoodsToOrders> GoodsToOrders { get; set; }
    }
}
