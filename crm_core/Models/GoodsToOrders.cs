using System;
using System.Collections.Generic;

namespace crm_core
{
    public partial class GoodsToOrders : Models.AbstractModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? GoodId { get; set; }
        public int? ServiceId { get; set; }

        public virtual Goods Good { get; set; }
        public virtual Deals Order { get; set; }
        public virtual Services Service { get; set; }
    }
}
