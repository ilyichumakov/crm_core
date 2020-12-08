using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace crm_core
{
    public partial class Documents : Models.AbstractModel
    {
        public int Id { get; set; }
        public NpgsqlPath Path { get; set; }
        public string Title { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
    }
}
