using System;
using System.Collections.Generic;

namespace crm_core
{
    public partial class LegalPerson : Models.AbstractModel
    {
        public LegalPerson()
        {
            Deals = new HashSet<Deals>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string ContactPhone { get; set; }
        public int? Representative { get; set; }
        public string Itin { get; set; }
        public string Bik { get; set; }
        public string Kpp { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }

        public virtual NaturalPerson RepresentativeNavigation { get; set; }
        public virtual ICollection<Deals> Deals { get; set; }
    }
}
