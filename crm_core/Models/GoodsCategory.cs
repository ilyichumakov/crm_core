using System;
using System.Collections.Generic;

namespace crm_core
{
    public partial class GoodsCategory
    {
        public GoodsCategory()
        {
            Goods = new HashSet<Goods>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }

        public virtual ICollection<Goods> Goods { get; set; }
    }
}
