using System;
using System.Collections.Generic;

namespace crm_core
{
    public partial class NaturalPerson
    {
        public NaturalPerson()
        {
            Deals = new HashSet<Deals>();
            LegalPerson = new HashSet<LegalPerson>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string ContactPhone { get; set; }
        public string AdditionalPhone { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }

        public virtual ICollection<Deals> Deals { get; set; }
        public virtual ICollection<LegalPerson> LegalPerson { get; set; }
    }
}
