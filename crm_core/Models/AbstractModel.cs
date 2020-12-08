using System;
using System.Collections.Generic;
using System.Text;

namespace crm_core.Models
{
    public abstract class AbstractModel
    {
        public void save()
        {
            using (crmContext db = new crmContext())
            {
                if(this.GetType().GetProperty("DtUpdated") != null)
                {
                    var now = DateTime.Now;
                    if (this.GetType().GetProperty("DtCreated") != null)
                        if (this.GetType().GetProperty("DtCreated").GetValue(this) == null)
                            this.GetType().GetProperty("DtCreated").SetValue(this, now);
                    this.GetType().GetProperty("DtUpdated").SetValue(this, now);
                }
                db.Entry(this).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void delete()
        {
            using (crmContext db = new crmContext())
            {
                db.Entry(this).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
