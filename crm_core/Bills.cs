using System;
using System.Collections.Generic;

namespace crm_core
{
    public partial class Bills
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Status { get; set; }
        public double PricePaid { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }

        public virtual Deals Order { get; set; }
        public virtual Statuses StatusNavigation { get; set; }
    }
}
