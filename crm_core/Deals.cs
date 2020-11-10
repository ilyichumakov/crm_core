using System;
using System.Collections.Generic;

namespace crm_core
{
    public partial class Deals
    {
        public Deals()
        {
            Bills = new HashSet<Bills>();
            GoodsToOrders = new HashSet<GoodsToOrders>();
        }

        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public int? ClientId { get; set; }
        public int Status { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }

        public virtual NaturalPerson Client { get; set; }
        public virtual LegalPerson Company { get; set; }
        public virtual Statuses StatusNavigation { get; set; }
        public virtual ICollection<Bills> Bills { get; set; }
        public virtual ICollection<GoodsToOrders> GoodsToOrders { get; set; }
    }
}
