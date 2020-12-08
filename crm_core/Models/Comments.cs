using System;
using System.Collections.Generic;

namespace crm_core
{
    public partial class Comments : Models.AbstractModel
    {
        public Comments()
        {
            InverseComment = new HashSet<Comments>();
        }

        public int Id { get; set; }
        public int? PostId { get; set; }
        public int? CommentId { get; set; }
        public string Content { get; set; }
        public int Author { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }

        public virtual Staff AuthorNavigation { get; set; }
        public virtual Comments Comment { get; set; }
        public virtual Posts Post { get; set; }
        public virtual ICollection<Comments> InverseComment { get; set; }
    }
}
