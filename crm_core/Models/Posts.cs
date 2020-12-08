using System;
using System.Collections.Generic;

namespace crm_core
{
    public partial class Posts : Models.AbstractModel
    {
        public Posts()
        {
            Comments = new HashSet<Comments>();
        }

        public int Id { get; set; }
        public int Author { get; set; }
        public DateTime DtCreated { get; set; }
        public string Content { get; set; }
        public DateTime DtUpdated { get; set; }

        public virtual Staff AuthorNavigation { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
